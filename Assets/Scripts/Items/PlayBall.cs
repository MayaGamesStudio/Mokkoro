using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayBall : DragDrop {

    [SerializeField] private float maxVelocity;
    [SerializeField] private Vector2 objectSize;
    [SerializeField] private float topScreenOffset, botScreenOffset;

    private Rigidbody2D body2D;
    private List<Vector2> lastPositions;
    private float sideBoundary, topBoundary, botBoundary;

    protected override void Start() {
        base.Start();
        lastPositions = new List<Vector2>();
        body2D = GetComponent<Rigidbody2D>();
        sideBoundary = Screen.width / 2 - objectSize.x;
        topBoundary = Screen.height / 2 - objectSize.y - topScreenOffset;
        botBoundary = -Screen.height / 2 + objectSize.y + botScreenOffset;
    }

    private void Update() {
        if(body2D.velocity.magnitude != 0) {
            PetsManager.Instance.CurrentPet.Play(5);
        }
    }

    public override void OnPointerDown(PointerEventData eventData) {
        base.OnPointerDown(eventData);
        body2D.velocity = Vector2.zero;
    }

    public override void OnDrag(PointerEventData eventData) {
        base.OnDrag(eventData);

        Vector2 delta = Vector2.zero;
        delta.x = Mathf.Clamp(rectTransform.anchoredPosition.x,sideBoundary * -1,sideBoundary);
        delta.y = Mathf.Clamp(rectTransform.anchoredPosition.y,botBoundary,topBoundary);

        rectTransform.anchoredPosition = delta;
        if(lastPositions.Count >= 5) {
            lastPositions.RemoveAt(0);
            for(int i = 1; i < lastPositions.Count; i++) {
                lastPositions[i - 1] = lastPositions[i];
            }
        }
        lastPositions.Add(rectTransform.anchoredPosition);
    }

    public override void OnEndDrag(PointerEventData eventData) {
        var position = rectTransform.anchoredPosition;
        var direction = position - lastPositions[2];
        Debug.Log(direction);
        direction.x = Mathf.Clamp(direction.x,-maxVelocity,maxVelocity);
        direction.y = Mathf.Clamp(direction.y,-maxVelocity,maxVelocity);
        body2D.velocity = direction;
    }

    private void LateUpdate() {
        Vector2 delta = Vector2.zero;
        delta.x = Mathf.Clamp(rectTransform.anchoredPosition.x,sideBoundary * -1,sideBoundary);
        delta.y = Mathf.Clamp(rectTransform.anchoredPosition.y,botBoundary,topBoundary);

        rectTransform.anchoredPosition = delta;

        if(rectTransform.anchoredPosition.x > sideBoundary || rectTransform.anchoredPosition.x < -sideBoundary) {
            Bounce(new Vector2(-1,1));
        }
        if(rectTransform.anchoredPosition.y > topBoundary || rectTransform.anchoredPosition.y < botBoundary) {
            Bounce(new Vector2(1,-1));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.CompareTag("Boundry")) {
            var boundry = collision.GetComponent<Boundry>();
            if(boundry.left || boundry.right) {
                Bounce(new Vector2(-1,1));
            } else if(boundry.top || boundry.bot) {
                Bounce(new Vector2(1,-1));
            }
        }
    }

    private void Bounce(Vector2 bounceMultiply) {
        body2D.velocity *= bounceMultiply;
    } 
}

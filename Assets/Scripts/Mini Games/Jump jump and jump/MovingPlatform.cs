using UnityEngine;

public class MovingPlatform : Platform {
    public float MovingSpeed;

    private Vector3 targetPosition;

    // Update is called once per frame
    protected override void Update() {
        base.Update();
        if(Vector2.Distance(transform.position, targetPosition) <= 0.1f) {
            targetPosition = new Vector3(-targetPosition.x,targetPosition.y);
        }
        transform.position = Vector2.MoveTowards(transform.position,targetPosition,MovingSpeed * Time.deltaTime);
    }

    private void OnEnable() {
        targetPosition = new Vector3(-5f,transform.position.y);
    }
}

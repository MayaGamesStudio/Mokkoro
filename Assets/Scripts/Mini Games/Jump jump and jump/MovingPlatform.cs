using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    public float MovingSpeed;

    private Vector3 targetPosition;

    private void Start() {
        targetPosition = new Vector3(-5f,transform.position.y);
    }
    // Update is called once per frame
    void Update() {
        if(Vector2.Distance(transform.position, targetPosition) <= 0.1f) {
            targetPosition = new Vector3(-targetPosition.x,targetPosition.y);
        }
        transform.position = Vector2.MoveTowards(transform.position,targetPosition,MovingSpeed * Time.deltaTime);
    }
}

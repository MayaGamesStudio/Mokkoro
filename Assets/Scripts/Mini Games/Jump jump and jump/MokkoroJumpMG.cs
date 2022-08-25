using UnityEngine;

public class MokkoroJumpMG : MokkoroMiniGames {
    public float JumpSpeed, MoveSpeed;

    // Update is called once per frame
    protected override void Update() {
        var x = Input.GetAxisRaw("Horizontal");
        if(x != 0) {
            Move(x);
        } else {
            body2D.velocity = new Vector2(0,body2D.velocity.y);
        }
    }

    private void Move(float direction) {
        body2D.velocity = new Vector2(direction * MoveSpeed,body2D.velocity.y);
        if(transform.position.x < -8.5f) {
            transform.position = new Vector3(-transform.position.x - 0.5f,transform.position.y);
        }
        if(transform.position.x > 8.5f) {
            transform.position = new Vector3(-transform.position.x + 0.5f,transform.position.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(body2D.velocity.y > 0) return;
        if(collision.gameObject.CompareTag("Ground")) {
            body2D.AddForce(Vector2.up * JumpSpeed);
        }
        if(collision.gameObject.CompareTag("BrokenPlatform")) {
            body2D.AddForce(Vector2.up * JumpSpeed);
            ((PlatformsObjectPool) GenericObjectPool.Instance).BrokenPlatfomsPool.Release(collision.gameObject);
        }
    }
}

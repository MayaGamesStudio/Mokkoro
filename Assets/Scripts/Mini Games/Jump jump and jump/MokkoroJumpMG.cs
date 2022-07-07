using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MokkoroJumpMG : MonoBehaviour {
    public float JumpSpeed, MoveSpeed;

    private Rigidbody2D body2D;

    // Start is called before the first frame update
    void Start() {
        body2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update() {
        var x = Input.GetAxisRaw("Horizontal");
        if(x != 0) {
            Move(x);
        } else {
            body2D.velocity = new Vector2(0,body2D.velocity.y);
        }
    }

    private void Move(float direction) {
        body2D.velocity = new Vector2(direction * MoveSpeed,body2D.velocity.y);
        if(transform.position.x < -6) {
            transform.position = new Vector3(-transform.position.x - 0.5f,transform.position.y);
        }
        if(transform.position.x > 6) {
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
            Destroy(collision.gameObject);
        }
    }
}

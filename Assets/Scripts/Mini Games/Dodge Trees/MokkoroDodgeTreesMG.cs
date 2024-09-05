using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MokkoroDodgeTreesMG : MokkoroMiniGames {
    public float JumpSpeed;
    public float MaxTimePressed;
    private float timePressed = 0;
    private bool isFalling, isGrounded;

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
        if(Input.GetMouseButton(0) && !isFalling) {
            timePressed += Time.deltaTime;
            if(timePressed >= MaxTimePressed) {
                isFalling = true;
            } else {
                Jump();
            }
        } else {
            isFalling = isGrounded ? false : true;
        }
    }

    private void Jump() {
        body2D.velocity = new Vector2(body2D.velocity.x, JumpSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isFalling = false;
            isGrounded = true;
            timePressed = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour {

    public int playerSpeed = 10;
    private bool facingRight = false;
    private int playerJumpPower = 1250;
    public float moveX;
    private bool isGrounded;

	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        if (SceneManager.GetActiveScene().name == "Store")
        {
            if (moveX < 0.0f && facingRight == false)
                FlipPlayer();
            else if (moveX > 0.0f && facingRight == true)
                FlipPlayer();

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    void FlipPlayer()
    {
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= 1;
        transform.localScale = localScale;
    }

   private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
            isGrounded = true;
    }
}

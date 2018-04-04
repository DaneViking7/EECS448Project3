using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public int playerSpeed = 10;
    private int playerJumpPower = 1250;
    private float moveX;
    private bool isGrounded;

	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove()
    {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
            isGrounded = true;
    }
}

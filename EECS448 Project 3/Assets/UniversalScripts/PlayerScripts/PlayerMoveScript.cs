using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour {

    public int playerSpeed = 10;
	private int playerJumpPower = 1250;
	private int jumpsRem = 2;
	private bool moonBoots = false; //!< boolean to indicate possession of moon shoes
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
            if (moveX < 0.0f)
                GetComponent<SpriteRenderer>().flipX = true;
            else if (moveX > 0.0f)
                GetComponent<SpriteRenderer>().flipX = false;

            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if (moveX != 0 && isGrounded == true)
                GetComponent<Animator>().SetBool("IsRunning", true);
            else
                GetComponent<Animator>().SetBool("IsRunning", false);
        }
        else
        {
			GetComponent<SpriteRenderer>().flipX = false;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            if(isGrounded == true)
                GetComponent<Animator>().SetBool("IsRunning", true);
            else
                GetComponent<Animator>().SetBool("IsRunning", false);
        }
    }

	void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		if (moonBoots == true) 
		{
			jumpsRem--;
			if (jumpsRem == 0)
				isGrounded = false;
		}
		else
        	isGrounded = false;
    }

	private void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "ground")
		{
			isGrounded = true;
			jumpsRem = 2;
		}
    }

	private void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.name == "MoonBoots")
		{
			moonBoots = true;
		}
		if(trig.gameObject.tag == "lvlend")
		{
			moonBoots = false;
		}
	}
}

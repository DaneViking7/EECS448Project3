using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour {

	GameObject Dino; //! reference to the player
	PlayerScore targetScript; //! reference to the PlayerScore script
	public int playerSpeed = 10; //! the player's movement speed
	private bool moonBoots = false; //! true if the player has the moonBoots powerup for the level, false otherwise
	private int playerJumpPower = 1250; //! player's jump power
	private int jumpsRem = 2; //! player's jumps remaining if they have the moonBoots powerup
	public float moveX; //! direction the player is running
	private bool isGrounded; //! true if the player is touching the ground, false otherwise

	//! sets the script's member variables
	void Start()
	{
		Dino = GameObject.Find("Dino");
		targetScript  = Dino.GetComponent<PlayerScore>();
	}

	//! checks for movement related test input and if the player is causing the dino to move or has a movement related power up
	void Update () {
        PlayerMove();
		if (targetScript.jetPack == true)
			playerJumpPower = 2000;
		if (targetScript.moonBoots == true)
			moonBoots = true;
		if (Input.GetKeyDown ("4") && SceneManager.GetActiveScene ().name == "Test")
		{
			if (playerJumpPower == 1250)
				playerJumpPower = 2000;
			else
				playerJumpPower = 1250;
		}
		if (Input.GetKeyDown ("7") && SceneManager.GetActiveScene ().name == "Test")
		{
			if (moonBoots == false)
				moonBoots = true;
			else
				moonBoots = false;
		}
	}

	//! runs player movement, physics, and turning
	void PlayerMove()
    {
        moveX = Input.GetAxis("Horizontal");
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
		if (SceneManager.GetActiveScene().name == "Store" || SceneManager.GetActiveScene().name == "Test")
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

	//! runs player jumping, allows one jump normally and 2 with moon boots power up
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

	//! detects when the player touches the ground to refresh their jump count
	private void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.tag == "ground")
		{
			isGrounded = true;
			jumpsRem = 2;
		}
    }

	//! gets rid of movement based power ups on level end
	private void OnTriggerEnter2D(Collider2D trig)
	{
		if(trig.gameObject.tag == "lvlend")
		{
			moonBoots = false;
			playerJumpPower = 1250;
		}
	}
}

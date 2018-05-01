using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour {

	GameObject Dino;
	PlayerScore targetScript;
    public int playerSpeed = 10;
	private bool moonBoots = false;
	private int playerJumpPower = 1250;
	private int jumpsRem = 2;
	public float moveX;
	private bool isGrounded;

	void Start()
	{
		Dino = GameObject.Find("Dino");
		targetScript  = Dino.GetComponent<PlayerScore>();
	}

	// Update is called once per frame
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
		if(trig.gameObject.tag == "lvlend")
		{
			moonBoots = false;
			playerJumpPower = 1250;
		}
	}
}

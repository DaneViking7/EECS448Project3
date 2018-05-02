using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour {

	GameObject Dino;//! reference to the player dino object
	private int speed = 15; //!< speed that fireball moves across screen

	//! flips the fireball to face the direction the dino is facing
	void Start() {
		Dino = GameObject.Find("Dino");
		if (Dino.GetComponent<SpriteRenderer> ().flipX == true) {
			GetComponent<SpriteRenderer> ().flipX = true;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0) * speed;
		}
		else
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
	}

	//! destroys the fireball and the kill object when the fireball connects with it
	private void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.tag == "Kill Object")
		{
			Destroy (trig.gameObject);
			Destroy (this.gameObject);
		}
	}
}
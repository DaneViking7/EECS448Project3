using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour {

	GameObject Dino;
	private int speed = 15; //!< speed that dinosaur moves across screen

	void Start() {
		Dino = GameObject.Find("Dino");
		if (Dino.GetComponent<SpriteRenderer> ().flipX == true) {
			GetComponent<SpriteRenderer> ().flipX = true;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0) * speed;
		}
		else
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * speed;
	}

	private void OnTriggerEnter2D(Collider2D trig)
	{
		if (trig.gameObject.tag == "Kill Object")
		{
			Destroy (trig.gameObject);
			Destroy (this.gameObject);
		}
	}
}
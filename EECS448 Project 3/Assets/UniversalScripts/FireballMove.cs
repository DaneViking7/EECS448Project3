using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour {

	private int speed = 15; //!< speed that dinosaur moves across screen

	// Update is called once per frame
	void Update () {
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
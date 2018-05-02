﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private int enemySpeed = 5; //!< speed that dinosaur moves across screen
	int direction = 1; 
	// Update is called once per frame
	void Update () {
		double ceiling = 4.5; //!< the highest point an enemy can move
		double floor = -4; //!< the lowest point an enemy can move

		float velocity = 3; //!< how fast the enemy moves toward the dinosaur

		if (gameObject.name == "puffy" || gameObject.name == "Bee" || gameObject.name == "Ghost" || gameObject.name == "puffy(Clone)" || gameObject.name == "Bee(Clone)" || gameObject.name == "Ghost(Clone)") {
			if (transform.position.y >= ceiling) {
				direction = -1;
			}
			if (transform.position.y <= floor) {
				direction = 1;
			}
			transform.Translate (0, velocity * direction * Time.deltaTime, 0);
		} else {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0) * enemySpeed;
		}
	}
}

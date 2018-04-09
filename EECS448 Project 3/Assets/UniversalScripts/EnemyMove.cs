﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private int enemySpeed = 5; //!< speed that dinosaur moves across screen
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0) * enemySpeed;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private int enemySpeed = 5; //!< speed that dinosaur moves across screen
	int direction = 1; //!< positive for moving right/up and negative for moving down/left
	// Update is called once per frame
	void Update () {
		double ceiling = 4.5; //!< max for functions that move up and down
		double floor = -4; //!< min for functions that move up and down

		float velocity = 3; //!< how fast they will go up and down
		if (gameObject.name == "puffy" || gameObject.name == "Bee" || gameObject.name == "Ghost" || gameObject.name == "puffy(Clone)" || gameObject.name == "Bee(Clone)" || gameObject.name == "Ghost(Clone)") {
			if (transform.position.y >= ceiling) {
				direction = -1; //!< go back down if at or above max
			}
			if (transform.position.y <= floor) {
				direction = 1; //!< go back up if at or below min
			}
			transform.Translate (0, velocity * direction * Time.deltaTime, 0); //!< transformation for up/down movement
		} else if (gameObject.name == "twc" || gameObject.name == "twc(Clone)") {
			enemySpeed = 2;
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (1, 0) * enemySpeed; //!< enemy moves in positive x direction
		} else if (gameObject.name == "rabbit" || gameObject.name == "rabbit(Clone)") {
			enemySpeed = 40; //!< rabbit bounces up and down very fast
			ceiling = -2.25;
			floor = -3.75;
			if (transform.position.y >= ceiling) {
				direction = -1;
			}
			if (transform.position.y <= floor) {
				direction = 1;
			}
			transform.Translate (0, velocity * direction * Time.deltaTime, 0);
		} else if (gameObject.name == "peacock") {
			enemySpeed = 10;
			double right = 50; //!< maximum in x direction
			double left = 43; //!<minimum in x direction
			if (transform.position.x >= right) {
				direction = -1; //!< go back left if at or farther than max
			}
			if (transform.position.x <= left) {
				direction = 1; //!< go back right if at or less than min
			}
			transform.Translate (velocity * direction * Time.deltaTime, 0, 0); //!< transformation for right/left movement
		} else if (gameObject.name == "peacock (1)") {
			enemySpeed = 10;
			double right = 105;
			double left = 98;
			if (transform.position.x >= right) {
				direction = -1;
			}
			if (transform.position.x <= left) {
				direction = 1;
			}
			transform.Translate (velocity * direction * Time.deltaTime, 0, 0);
		}
		else if (gameObject.name == "peacock(Clone)") {
			enemySpeed = 10;
			double right = 440;
			double left = 433;
			if (transform.position.x >= right) {
				direction = -1;
			}
			if (transform.position.x <= left) {
				direction = 1;
			}
			transform.Translate (velocity * direction * Time.deltaTime, 0, 0);
		}
		else {
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1, 0) * enemySpeed; //!< all other enemies move in negative x direction
		}
	}
}

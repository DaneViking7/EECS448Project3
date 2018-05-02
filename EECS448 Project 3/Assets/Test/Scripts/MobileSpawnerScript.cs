using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSpawnerScript : MonoBehaviour {

	public GameObject prefab;//! reference to the prefab the spawner will generate
	private GameObject clone;//! reference to the object to be generated

	//! creates the prefab object when the player hits the spawner, places it in front of the spawner
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			clone = Instantiate (prefab, this.transform.position, this.transform.rotation);
			clone.transform.position = new Vector2(this.transform.position.x + 8, this.transform.position.y - 3.5f);
		}
	}
}

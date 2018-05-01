using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileSpawnerScript : MonoBehaviour {

	public GameObject prefab;
	private GameObject clone;

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			clone = Instantiate (prefab, this.transform.position, this.transform.rotation);
			clone.transform.position = new Vector2(this.transform.position.x + 8, this.transform.position.y - 3);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobileSpawnerScript : MonoBehaviour {

	public GameObject prefab;
	private GameObject clone;
	private bool canCreate = true;

	private void Update()
	{
		if (clone == null)
			canCreate = true;
		else
			canCreate = false;
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && canCreate == true) {
			clone = Instantiate (prefab, this.transform.position, this.transform.rotation);
			clone.transform.position = new Vector2(this.transform.position.x + 8, this.transform.position.y - 3.5f);
		}
	}
}

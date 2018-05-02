using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmobileSpawnerScript : MonoBehaviour {

	public GameObject prefab; //! reference to the prefab the spawner will generate
	private GameObject clone; //! reference to the object to be generated
	private bool canCreate = true; //! true if an object has not been made yet, false otherwise

	//! checks to see if an object can be created or not
	private void Update()
	{
		if (clone == null)
			canCreate = true;
		else
			canCreate = false;
	}

	//! creates the prefab object when the player hits the spawner, places it in front of the spawner
	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player" && canCreate == true) {
			clone = Instantiate (prefab, this.transform.position, this.transform.rotation);
			clone.transform.position = new Vector2(this.transform.position.x + 8, this.transform.position.y - 3.5f);
		}
	}
}

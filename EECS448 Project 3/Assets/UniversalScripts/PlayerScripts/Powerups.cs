using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	private bool egg = false; //!< boolean to indicate possession of egg
	private bool aerosol = false; //!< boolean to indicate possession of aerosol can
	private bool jetPack = false; //!< boolean to indicate possession of jetPack
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D trig)
	{
		// If dino collides with egg
		if (trig.gameObject.name == "Egg") {
			egg = true;
		}
		if (trig.gameObject.name == "Aerosol") {
			aerosol = true;
		}
		if (trig.gameObject.name == "JetPack") {
			jetPack = true;
		}
		if (trig.gameObject.tag == "lvlend") {
			egg = false;
			aerosol = false;
			jetPack = false;
		}
	}
}

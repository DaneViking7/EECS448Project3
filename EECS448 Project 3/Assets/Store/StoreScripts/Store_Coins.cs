using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Store_Coins : MonoBehaviour {

	//TODO: use actual amount of coins user has
	private float coins = 30; //!< number of coins the dino has earned
	public GameObject playerCoins; //!< object to display number of coins at the top
	private const int eggCost = 15; //!< the cost of an Egg powerup
	private const int moonBootsCost = 20; //!< the cost of a Moon Boots
	private bool displayExit = false; //!< boolean to enable/disable the Exit GUI menu
	private bool displayNotEnoughCoins = false; //!< boolean to enable/disable the Not Enough Coins GUI
	//TODO: use actual level counter from the dino
	private int levelCount = 1; //!< counter to count number of times the Dino has entered the store

		
	//! Update is called once per frame, updates coin display at top of screen
	void Update () {
		playerCoins.gameObject.GetComponent<Text> ().text = ("Coins: " + coins);
	}

	//! When dino jumps to a powerup, do something
	void OnTriggerEnter2D (Collider2D trig) {
		// If dino collides with egg
		if (trig.gameObject.name == "Egg") {
			// If dino has enough coins
			if (coins > eggCost) {
				coins -= eggCost;
				Destroy (trig.gameObject);
			} else { // if dino doesn't have enough coins
				displayNotEnoughCoins = true;
			}
		}
		// If dino collides with moon boots
		if (trig.gameObject.name == "MoonBoots") {
			// If dino has enough coins
			if (coins > moonBootsCost) {
				coins -= moonBootsCost;
				Destroy (trig.gameObject);
			} else { // if dino doesn't have enough coins
				displayNotEnoughCoins = true;
			}
		}
	}

	//! start a timer for the GUI when dino falls from powerup
	void OnTriggerExit2D (Collider2D trig) {
		StartCoroutine (Timer ());
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.name == "door") {
			displayExit = true;
		}
	}

	//! Display GUIs based on collisions with game objects
	void OnGUI () {
		// if dino collided with door, display exit GUI
		if (displayExit) {
			GUI.Box (new Rect (50, 37, 200, 46), "Are you sure you want to exit?");
			if (GUI.Button (new Rect (60, 59, 80, 20), "Yes")) {
				if (levelCount == 2) {
					SceneManager.LoadScene ("Level 2");
				}
				if (levelCount == 3) {
					SceneManager.LoadScene ("Level3");
				}
			}
			if (GUI.Button (new Rect (160, 59, 80, 20), "No")) {
				displayExit = false;
			}
		}
		// if collided with a power up but doesn't have enpough money, display coin GUI
		if (displayNotEnoughCoins) {
			GUI.Box (new Rect (50, 50, 200, 25), "You dont have enough coins!");
		}
	}
	
	//! Timer for displaying powerup GUI
	IEnumerator Timer() {
		yield return new WaitForSecondsRealtime (1);
		displayNotEnoughCoins = false;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store_Coins : MonoBehaviour {

	private float coins = 0;
	public GameObject playerCoins;

	// Update is called once per frame
	void Update () {
		playerCoins.gameObject.GetComponent<Text> ().text = ("Coins: " + coins);
	}
}

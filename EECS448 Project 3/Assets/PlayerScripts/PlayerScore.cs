using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    private int coinCount = 0;
    public GameObject coinCountUI;
	
	// Update is called once per frame
	void Update () {
        coinCountUI.gameObject.GetComponent<Text>().text = ("Coins: " + coinCount);
	}

    private void OnTriggerEnter2D(Collider2D trig)
    {
        
    }
}
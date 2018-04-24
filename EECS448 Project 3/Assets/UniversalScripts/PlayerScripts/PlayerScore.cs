﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {

	private int coinCount = 0; //!< number of coins the dino has earned
    public GameObject canvas; //!< canvas to display number of coins at the top
    public GameObject coinCountUI; //!< object to display number of coins at the top
	private bool moonshoes = false; //!< boolean to indicate possession of moon shoes
	private bool mini = false; //!< boolean to indicate possession of egg
	private bool heart = false; //!< boolean to indicate possession of heart
	private bool aerosolCan = false; //!< boolean to indicate possession of aerosol can
	private bool jetPack = false; //!< boolean to indicate possession of jetPack
	private int lvl = 1; //!< counter to count number of times the Dino has entered the store
	private const int eggCost = 5; //!< the cost of an Egg powerup
	private const int moonBootsCost = 10; //!< the cost of a Moon Boots powerup
	private const int heartCost = 25; //!< the cost of a Heart powerup
	private const int aerosolCanCost = 15; //!< the cost of an Aerosol Can powerup
	private const int jetPackCost = 20; //!< the cost of a Jet Pack powerup
	private bool displayExit = false; //!< boolean to enable/disable the Exit GUI menu
	private bool displayNotEnoughCoins = false; //!< boolean to enable/disable the Not Enough Coins GUI

    // Update is called once per frame
	void Update () {
        coinCountUI.gameObject.GetComponent<Text>().text = ("Coins: " + coinCount);
	}

	private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "lvlend")
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(canvas);
            lvl++;
            transform.position = new Vector2(-8.06f, -3.956429f);
            SceneManager.LoadScene("Store", LoadSceneMode.Single);
        }
        if(trig.gameObject.tag == "coin")
        {
            coinCount++;
            Destroy(trig.gameObject);
        }
        // If dino collides with egg
        if (trig.gameObject.name == "Egg")
        {
            // If dino has enough coins
            if (coinCount >= eggCost)
            {
                coinCount -= eggCost;
                Destroy(trig.gameObject);
                mini = true;
            }
            else
            { // if dino doesn't have enough coins
                displayNotEnoughCoins = true;
            }
        }
        // If dino collides with moon boots
        if (trig.gameObject.name == "MoonBoots")
        {
            // If dino has enough coins
            if (coinCount >= moonBootsCost)
            {
                coinCount -= moonBootsCost;
                Destroy(trig.gameObject);
                moonshoes = true;
            }
            else
            { // if dino doesn't have enough coins
                displayNotEnoughCoins = true;
            }
        }
		// If dino collides with heart
		if (trig.gameObject.name == "Heart")
		{
			// If dino has enough coins
			if (coinCount >= heartCost)
			{
				coinCount -= heartCost;
				Destroy(trig.gameObject);
				heart = true;
			}
			else
			{ // if dino doesn't have enough coins
				displayNotEnoughCoins = true;
			}
		}
		// If dino collides with aerosol can
		if (trig.gameObject.name == "Aerosol")
		{
			// If dino has enough coins
			if (coinCount >= aerosolCanCost)
			{
				coinCount -= aerosolCanCost;
				Destroy(trig.gameObject);
				aerosolCan = true;
			}
			else
			{ // if dino doesn't have enough coins
				displayNotEnoughCoins = true;
			}
		}
		// If dino collides with aerosol can
		if (trig.gameObject.name == "JetPack")
		{
			// If dino has enough coins
			if (coinCount >= jetPackCost)
			{
				coinCount -= jetPackCost;
				Destroy(trig.gameObject);
				jetPack = true;
			}
			else
			{ // if dino doesn't have enough coins
				displayNotEnoughCoins = true;
			}
		}
    }

    //! start a timer for the GUI when dino falls from powerup
	void OnTriggerExit2D(Collider2D trig)
    {
        StartCoroutine(Timer());
    }

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "door")
        {
            displayExit = true;
        }
    }

    //! Display GUIs based on collisions with game objects
	void OnGUI()
    {
        // if dino collided with door, display exit GUI
        if (displayExit)
        {
            GUI.Box(new Rect(50, 37, 200, 46), "Are you sure you want to exit?");
            if (GUI.Button(new Rect(60, 59, 80, 20), "Yes"))
            {
                if (lvl == 2)
                {
                    SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
                    transform.position = new Vector2(-5.72f, -3.14f);
                }
                if (lvl == 3)
                {
                    SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                    transform.position = new Vector2(-8.06f, -3.956429f);
                }
                displayExit = false;
            }
            if (GUI.Button(new Rect(160, 59, 80, 20), "No"))
            {
                displayExit = false;
            }
        }
        // if collided with a power up but doesn't have enpough money, display coin GUI
        if (displayNotEnoughCoins)
        {
            GUI.Box(new Rect(50, 50, 200, 25), "You dont have enough coins!");
        }
    }

    //! Timer for displaying powerup GUI
	IEnumerator Timer()
    {
        yield return new WaitForSecondsRealtime(1);
        displayNotEnoughCoins = false;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	//! loads the main menu when the button is clicked
	public void LoadMainMenu(){
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	//! restarts the game at level 1 when the button is clicked
	public void LoadLevel1(){
		SceneManager.LoadScene ("Level 1", LoadSceneMode.Single);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public void LoadMainMenu(){
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
	public void LoadLevel1(){
		SceneManager.LoadScene ("Level 1", LoadSceneMode.Single);
	}
}

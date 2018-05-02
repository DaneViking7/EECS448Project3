﻿/*
 * @file - PauseMenu
 * @author - Ron Huff
 * @date - 
 * @brief - 
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    #region Variables

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

	private bool music = true;
    

	#endregion

	#region Unity Methods

	// Update is called once per frame
	void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
	}

    #endregion

    void PauseGame()
    {
		if (Time.timeScale == 1) {
			pauseMenuUI.SetActive (true);
			Time.timeScale = 0f;
			GameIsPaused = true;
		}
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadGameMenu()
    {
		GameObject Dino = GameObject.Find("Dino");
		GameObject Canvas = GameObject.Find ("Canvas");
		Destroy (Dino);
		Destroy (Canvas);
        SceneManager.LoadScene("Menu");
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

	public void ToggleMusic()
	{
		if (music == true) {
			music = false;
			AudioListener.pause = true;
		} 
		else {
			music = true;
			AudioListener.pause = false;
		}
	}
}

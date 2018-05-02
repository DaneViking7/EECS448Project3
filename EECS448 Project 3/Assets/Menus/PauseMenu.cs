/*
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

	//! checks to see if the player hit the pause button
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

	//! pauses the game and displays the pause menu
    void PauseGame()
    {
		if (Time.timeScale == 1) {
			pauseMenuUI.SetActive (true);
			Time.timeScale = 0f;
			GameIsPaused = true;
		}
    }

	//! hides the pause menu and resumes the game
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

	//! loads the main menu when the button is clicked
    public void LoadGameMenu()
    {
		GameObject Dino = GameObject.Find("Dino");
		GameObject Canvas = GameObject.Find ("Canvas");
		Destroy (Dino);
		Destroy (Canvas);
        SceneManager.LoadScene("Menu");
        pauseMenuUI.SetActive(false);
    }

	//! ends the game
    public void QuitGame()
    {
        Application.Quit();
    }

	//! turns on or off the music
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

/*
 * @file - MainMenu
 * @author - Ron Huff
 * @date - 
 * @brief - 
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    #region Variables

	public GameObject mainMenuUI; //! reference to the main menu's ui

    #endregion

	//! starts the game at level 1
    public void StartGame()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

	//! starts the game in its test suite
	public void TestMode()
	{
		mainMenuUI.SetActive(false);
		Time.timeScale = 1f;
		PauseMenu.GameIsPaused = false;
		SceneManager.LoadScene("Test", LoadSceneMode.Single);
	}

	//! ends the game
    public void QuitGame()
    {
        Application.Quit();
    }
}

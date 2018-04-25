/*
 * @file - PauseMenu
 * @author - Ron Huff
 * @date - 
 * @brief - 
 */

using UnityEngine;

public class PauseMenu : MonoBehaviour {

    #region Variables

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


	#endregion

	#region Unity Methods


	// Use this for initialization

	
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
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void LoadGameMenu()
    {
        //Time.timeScale = 1f;
        Debug.Log("Not yet implemented.");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
}

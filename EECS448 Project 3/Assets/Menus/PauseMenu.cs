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
    public PlayerScore pScore;
    public PlayerHealth pHealth;
    

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
        Debug.Log("Loading Game Menu");
        pScore.coinCount = 0;
        pHealth.lives = 0;
        //gameObject.transform.Find("Lives").GetComponent<Text>().text = "Lives: 3";
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        pauseMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
}

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

    public GameObject mainMenuUI;

    #endregion

    #region Unity Methods


    // Use this for initialization
    void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

    #endregion

    public void StartGame()
    {
        mainMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

	public void TestMode()
	{
		mainMenuUI.SetActive(false);
		Time.timeScale = 1f;
		PauseMenu.GameIsPaused = false;
		SceneManager.LoadScene("Test", LoadSceneMode.Single);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}

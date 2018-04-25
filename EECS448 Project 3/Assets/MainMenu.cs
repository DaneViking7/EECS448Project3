/*
 * @file - MainMenu
 * @author - Ron Huff
 * @date - 
 * @brief - 
 */

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    #region Variables

    public static bool GameIsRunning = false;

    public GameObject MainMenuUI;

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
        Debug.Log("Starting game....Loading Scene: Level 1.");
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        //SceneManager.LoadScene("Store", LoadSceneMode.Single);
        GameIsRunning = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting application.");
        Application.Quit();
    }
}

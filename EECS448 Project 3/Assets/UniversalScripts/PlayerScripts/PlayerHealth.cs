using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public GameObject pt1; //! reference to the first pterodactyl in level 1
	public GameObject pt2; //! reference to the second pterodactyl in level 1
	public GameObject pt3; //! reference to the third pterodactyl in level 1
	GameObject Dino; //! reference to the dino
	PlayerScore targetScript; //! reference to the PlayerScore script
	private bool heart; //! Adds 1 to the player's lives if the player buys the heart powerup
	private bool dead; //!< boolean to indicate whether or not player died
    public GameObject canvas; //!< object to display number of coins on the screen
	public GameObject livesCountUI; //! displays the number of player lives remaining
	public GameObject godModeUI; //! displays whether god mode is on or off in the test suite
	private int lives; //! keeps track of the number of player lives remaining
	bool invincible; //! true for god mode, false otherwise

	//! initializes member variables
	void Start()
    {
		Time.timeScale = 1;
		Dino = GameObject.Find("Dino");
		targetScript  = Dino.GetComponent<PlayerScore>();
        dead = false;
		lives = 3;
		invincible = false;
    }

	//! Checks for health related test input and keeps track of the player's lives
	void Update()
    {
		if (Input.GetKeyDown ("1") && SceneManager.GetActiveScene ().name == "Test")
		{
			if (invincible == false)
				invincible = true;
			else
				invincible = false;
		}
		if (Input.GetKeyDown ("3") && SceneManager.GetActiveScene ().name == "Test") {
			lives++;
		}
		heart = targetScript.heart;
		if (heart == true)
		{
			lives++;
			heart = false;
			targetScript.heart = false;
		}
		livesCountUI.gameObject.GetComponent<Text>().text = ("Lives: " + lives);
		if(SceneManager.GetActiveScene ().name == "Test")
		{
			if (invincible == false)
				godModeUI.gameObject.GetComponent<Text> ().text = ("God Mode: Off");
			else
				godModeUI.gameObject.GetComponent<Text> ().text = ("God Mode: On");
		}
		if (lives == 0)
			dead = true;
        if (dead == true)
            Die();
    }

	//! Transitions to the death screne
	void Die()
    {
		GameObject hero = GameObject.Find("Hero");
		Destroy (hero);
        Destroy(this.gameObject);
        Destroy(canvas);
		if (SceneManager.GetActiveScene ().name == "Test")
			SceneManager.LoadScene ("Test", LoadSceneMode.Single);
		else
        	SceneManager.LoadScene("Death", LoadSceneMode.Single);
    }

	//! Detects when the player collides with an object that would kill it and decides what will happen to the player
	private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Kill Object" && invincible == false)
		{
			lives--;
			if (SceneManager.GetActiveScene ().name == "Test")
			{
				transform.position = new Vector2(-8.06f, -3.95642f);
			}
			if (SceneManager.GetActiveScene ().name == "Level 1")
			{
				pt1.transform.position = new Vector2 (15.93f, 0.18f);
				pt2.transform.position = new Vector2 (86.4917f, 0.234636f);
				pt3.transform.position = new Vector2 (180.9456f, -0.68078f);
				transform.position = new Vector2(-8.06f, -3.95642f);
			}
			if (SceneManager.GetActiveScene().name == "Level 2")
			{
				SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
				transform.position = new Vector2(-5.72f, -3.14f);
			}
			if (SceneManager.GetActiveScene().name == "Level3")
			{
				SceneManager.LoadScene("Level3", LoadSceneMode.Single);
				transform.position = new Vector2(-8.06f, -3.956429f);
			}
			if (SceneManager.GetActiveScene().name == "Level4")
			{
				SceneManager.LoadScene("Level4", LoadSceneMode.Single);
				transform.position = new Vector2(-7.98f, -2.64641f);
			}
			if (SceneManager.GetActiveScene().name == "Level5")
			{
				SceneManager.LoadScene("Level5", LoadSceneMode.Single);
				transform.position = new Vector2(-8.06f, -3.95642f);
			}
			if (SceneManager.GetActiveScene().name == "Level6")
			{
				SceneManager.LoadScene("Level6", LoadSceneMode.Single);
				transform.position = new Vector2(-7.98986f, -3.77048f);
			}
			if (SceneManager.GetActiveScene().name == "Level7")
			{
				SceneManager.LoadScene("Level7", LoadSceneMode.Single);
				transform.position = new Vector2(-8.04778f, -3.70197f);
			}
			Time.timeScale = 0;
			StartCoroutine (Timer ());
		}
    }

	//! Timer for before the level starts again between lives
	IEnumerator Timer()
	{
		yield return new WaitForSecondsRealtime(1);
			Time.timeScale = 1;
	}
}

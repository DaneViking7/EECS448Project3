using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
	public GameObject pt1;
	public GameObject pt2;
	public GameObject pt3;
	GameObject Dino;
	PlayerScore targetScript;
	private bool heart;
	private bool dead; //!< boolean to indicate whether or not player died
    public GameObject canvas; //!< object to display number of coins on the screen
	public GameObject livesCountUI;
	private int lives;
	bool invincible;
    // Use this for initialization
	void Start()
    {
		Time.timeScale = 1;
		Dino = GameObject.Find("Dino");
		targetScript  = Dino.GetComponent<PlayerScore>();
        dead = false;
		lives = 3;
		invincible = false;
    }

    // Update is called once per frame
	void Update()
    {
		heart = targetScript.heart;
		if (heart == true)
		{
			lives++;
			heart = false;
			targetScript.heart = false;
		}
		livesCountUI.gameObject.GetComponent<Text>().text = ("Lives: " + lives);
		if (lives == 0)
			dead = true;
        if (dead == true)
            Die();
    }

	void Die()
    {
        Destroy(this.gameObject);
        Destroy(canvas);
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

	private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.tag == "Kill Object" && invincible == false)
		{
			lives--;
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
			Time.timeScale = 0;
			StartCoroutine (Timer ());
		}
    }

	//! Timer for displaying powerup GUI
	IEnumerator Timer()
	{
		yield return new WaitForSecondsRealtime(1);
		Time.timeScale = 1;
	}
}

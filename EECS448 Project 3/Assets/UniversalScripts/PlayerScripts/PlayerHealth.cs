using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
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
			lives--;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool godMode;
	private bool dead; //!< boolean to indicate whether or not player died
    public GameObject canvas; //!< object to display number of coins on the screen
    // Use this for initialization
	void Start()
    {
        dead = false;
    }

    // Update is called once per frame
	void Update()
    {
        if (dead == true && !godMode)
        {
            Die();
        }

    }

	void Die()
    {
        Destroy(this.gameObject);
        Destroy(canvas);
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

	private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Kill Object")
            dead = true;
    }
}

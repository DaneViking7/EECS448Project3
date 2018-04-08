using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public bool dead;

	// Use this for initialization
	void Start () {
		//GameObject player = GameObject.FindWithTag("Player");
        dead = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindWithTag("Player").transform.position.y <= -10.0f) {
			dead = true;
			Die();
		}
        if(dead == true) {
            Die();
        }

	}

    void Die () {
        SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Kill Object")
            dead = true;
    }
}

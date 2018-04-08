using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public bool dead;

	// Use this for initialization
	void Start () {
		//GameObject player = GameObject.FindWithTag("Player");

//I commented out the below line while fixing merge conflict. --Ron 4/8/18
//     private bool dead;
//     public GameObject canvas;
//     // Use this for initialization
//     void Start () {

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
        //SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
        Destroy(this.gameObject);
        Destroy(canvas);//Currently must uncomment this line in Level 2 -- Ron H. 4/8/18
        SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Kill Object")
            dead = true;
    }
}

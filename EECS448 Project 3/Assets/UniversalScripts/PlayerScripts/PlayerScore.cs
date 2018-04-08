using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour {

    private int coinCount = 0;
    public GameObject canvas;
    public GameObject coinCountUI;
    private bool moonshoes = false;
    private bool mini = false;

    // Update is called once per frame
    void Update () {
        coinCountUI.gameObject.GetComponent<Text>().text = ("Coins: " + coinCount);
	}

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "lvlend")
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(canvas);
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
        if(trig.gameObject.tag == "coin")
        {
            coinCount++;
            Destroy(trig.gameObject);
        }
    }
}
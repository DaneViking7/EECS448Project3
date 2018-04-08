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
    private int lvl = 1;

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
            if (SceneManager.GetActiveScene().name != "Store")
            {
                lvl++;
                transform.position = new Vector2(-8.06f, -3.956429f);
                SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
            }
            else
            {
                if (lvl == 2)
                {
                    SceneManager.LoadScene("Level 2", LoadSceneMode.Single);
                }
                else if (lvl == 3)
                {
                    SceneManager.LoadScene("Level3", LoadSceneMode.Single);
                }
            }
        }
        if(trig.gameObject.tag == "coin")
        {
            coinCount++;
            Destroy(trig.gameObject);
        }
    }
}
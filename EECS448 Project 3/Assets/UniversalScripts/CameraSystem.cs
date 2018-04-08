using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSystem : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {
        //float x = Mathf.Clamp(player.transform.position.x + 8, xMin, xMax);
        //float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        gameObject.transform.position = new Vector3(10, 0, gameObject.transform.position.z);
    
        //I commented out the below line while fixing merge conflict. --Ron 4/8/18
        //if (player != null)
        //{
            //float x = Mathf.Clamp(player.transform.position.x + 8, xMin, xMax);
            //float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            //gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        //}
	}
}

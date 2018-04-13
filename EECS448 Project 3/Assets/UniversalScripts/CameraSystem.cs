using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSystem : MonoBehaviour
{

	private GameObject player; //!<dino object
	public float xMin; //!< minimum x position for the camera
	public float xMax; //!< maximum x position for the camera
	public float yMin; //!< minimum y position for the camera
	public float yMax; //!< maximum y position for the camera

    // Use this for initialization
	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
	void LateUpdate()
    {
        if (player != null)
        {
            float x = Mathf.Clamp(player.transform.position.x + 5.5f, xMin, xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }
    }
}

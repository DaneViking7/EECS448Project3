/*
 * @file - SpotlightRotate
 * @author - Ron Huff
 * @date - 
 * @brief - 
 */

using UnityEngine;

public class SpotlightRotate : MonoBehaviour {

    #region Variables

    public float MoveSpeed = 4f;
    private bool dirRight = true;
	#endregion

	#region Unity Methods


	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(dirRight)
        {
            transform.Translate(Vector2.right * (MoveSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(-Vector2.right * (MoveSpeed * Time.deltaTime));
        }
        if(transform.position.x >= 122f)
        {
            dirRight = false;
        }
        else if(transform.position.x <= 114f)
        {
            dirRight = true;
        }
	}

	#endregion
	
}

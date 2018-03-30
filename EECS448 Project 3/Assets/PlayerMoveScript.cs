using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public int playerJumpPower = 375;

	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void PlayerMove()
    {
        //CONTROLS
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        //PHYSICS
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
    }
}

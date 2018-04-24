using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle = 0,
    Run = 1,
    Jump = 2,
    Death = 3
}

public class Player : CharacterBase {
    PlayerState curState;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            if (curState == PlayerState.Jump)
                return;
            Debug.Log("跳");
            Jump(jumpforce);
            SetState(PlayerState.Jump);
        }
	}

    public void SetState(PlayerState _state)
    {
        curState = _state;
    }
}

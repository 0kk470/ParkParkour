using System;
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

public class Player : CharacterBase
{
    PlayerState curState;
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        GameManager.GetInstance().OnGameOver += OnPlayerDeath;
    }

     void OnDisable() //Also called when destroyed
    {
        GameManager.GetInstance().OnGameOver -= OnPlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
#if UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            if (curState == PlayerState.Jump)
                return;
            Debug.Log("跳");
            Jump(jumpforce);
            SetState(PlayerState.Jump);
        }
#endif
#if UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 0)
        {
            if (curState == PlayerState.Jump)
                return;
            Jump(jumpforce);
        }
#endif
    }

    void OnPlayerDeath(object sender, EventArgs e)
    {
        Debug.Log("玩家死亡");
    }

    public override void Jump(float _jumpforce)
    {
        base.Jump(_jumpforce);
        SetState(PlayerState.Jump);
    }

    public void SetState(PlayerState _state)
    {
        curState = _state;
    }
}

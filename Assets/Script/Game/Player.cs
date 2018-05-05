using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public enum PlayerState
{
    Idle = 0,
    Run = 1,
    Jump = 2,
    Death = 3
}

public class Player : CharacterBase
{
    private PlayerState curState;
    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Init();
    }

    void Start()
    {
        GameManager.GetInstance().OnGameOver += OnPlayerDeath;
        GameManager.GetInstance().OnGameStart += OnPlayerStart;
    }

    void OnDisable() //Also called when destroyed
    {
        GameManager.GetInstance().OnGameOver -= OnPlayerDeath;
        GameManager.GetInstance().OnGameStart -= OnPlayerStart;
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        HandleAnimation();
    }

    void HandleInput()
    {
#if UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            if (curState == PlayerState.Jump)
                return;
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            Debug.Log("跳");
            Jump(jumpforce);
        }
#endif
#if UNITY_ANDROID || UNITY_IPHONE
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Debug.Log(EventSystem.current.gameObject.name);
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return;
            if (curState == PlayerState.Jump)
                return;
            Jump(jumpforce);
        }
#endif
    }

    private void HandleAnimation()
    {
        var cur_state = animator.GetInteger("State");
        var tar_state = (int)curState;
        if (cur_state != tar_state)
            animator.SetInteger("State", tar_state);
    }

    private void BeginMovement()
    {
        SetState(PlayerState.Run);
        rb2d.DOMoveX(-6.5f, 2f).SetEase(Ease.Linear).SetUpdate(false).onComplete = TerranManager.GetInstance().StartRollingTerran;
    }

    private void OnPlayerStart(object sender, EventArgs e)
    {
        Debug.Log("玩家开始行动");
        Init();
        BeginMovement();
    }

    private void OnPlayerDeath(object sender, EventArgs e)
    {
        SetState(PlayerState.Death);
        animator.SetTrigger("Death");
        Debug.Log("玩家死亡");
    }


    public void Init()
    {
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.velocity = Vector2.zero;
        SetState(PlayerState.Idle);
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

    public PlayerState GetPlayerState()
    {
        return curState;
    }
}

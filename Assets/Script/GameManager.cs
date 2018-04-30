using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GameStart,
    Gaming,
    GameOver
}

public class GameManager:MonoBehaviour{
    public Transform startPosition;
    public event EventHandler OnGameStart;
    public event EventHandler OnGameOver;
    public static GameState curState;
    private static GameManager instance;
    private Player player;
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        Init();
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void Init ()
    {
        curState = GameState.GameStart;
        instance = this;
    }

    public void StartGame(object sender,EventArgs e)
    {
        StartCoroutine(GameStartProcess(sender,e));
    }

    public void EndGame(object sender, EventArgs e)
    {
        StartCoroutine(GameOverProcess(sender, e));
    }

    public void ResetPlayer()
    {
        if (player == null)
            Debug.LogError("获取玩家索引失败");
        player.transform.position = startPosition.position;
        player.Init();
    }

    private IEnumerator GameStartProcess(object sender, EventArgs e)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("游戏开始");
        curState = GameState.Gaming;
        if (OnGameStart != null)
            OnGameStart(sender, e);
    }

    private IEnumerator GameOverProcess(object sender, EventArgs e)
    {
        if (OnGameOver != null)
            OnGameOver(sender, e);
        yield return new WaitForSeconds(2f);
        ResetPlayer();
    }
}

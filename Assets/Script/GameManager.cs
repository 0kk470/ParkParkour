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
    public event EventHandler OnGameStart;
    public event EventHandler OnGameOver;
    public static GameState curState;
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        Init();
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
        yield return new WaitForSeconds(2f);
        if (OnGameOver != null)
            OnGameOver(sender, e);
    }
}

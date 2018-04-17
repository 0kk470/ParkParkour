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

public class GameManager{
    public event EventHandler OnGameStart;
    public event EventHandler OnGameOver;
    public static GameState curState;
    private static GameManager instance;

    public static GameManager GetInstance()
    {
        if (instance == null)
            instance = new GameManager();
        return instance;
    }
	public static void Init ()
    {
        curState = GameState.GameStart;
	}

    public void StartGame()
    {
        if (OnGameStart != null)
            OnGameStart(this,EventArgs.Empty);
    }
}

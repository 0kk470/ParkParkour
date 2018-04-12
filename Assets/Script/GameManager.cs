using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    GameStart,
    GameOther,
    Gaming,
    GameOver
}

public class GameManager{
    public event EventHandler OnGameStateChange;
    public static GameState curState;
    private GameManager instance;

    public GameManager GetInstance()
    {
        if (instance == null)
            instance = new GameManager();
        return instance;
    }
	public static void Init ()
    {
        curState = GameState.GameStart;
	}

    public void ChangeState(object sender,EventArgs e)
    {
        if(OnGameStateChange != null)
          OnGameStateChange(sender, e);
    }


}

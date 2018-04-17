using LeanCloud;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AVClassName("PlayerData")]
public class PlayerData : AVObject
{
    [AVFieldName("playerName")]
    public string PlayerName
    {
        get { return GetProperty<string>("PlayerName"); }
        set { SetProperty(value, "PlayerName"); }
    }

    [AVFieldName("score")]
    public int Score
    {
        get { return GetProperty<int>("Score"); }
        set { SetProperty(value, "Score"); }
    }
}

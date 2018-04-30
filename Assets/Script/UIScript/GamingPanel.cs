using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventArgs : EventArgs
{

}

public class GamingPanel : MonoBehaviour, UIBase
{
    private Text score;
    private float scorevalue;
    // Use this for initialization
    void Awake()
    {
        score = transform.Find("Score").GetComponent<Text>();
        transform.Find("pause_btn").GetComponent<Button>().onClick.AddListener(OnPauseBtnClick);
    }

    void OnEnable()
    {
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scorevalue = Time.time * 10;
        score.text = "Score : " + Mathf.Ceil(scorevalue);
    }

    private void OnPauseBtnClick()
    {
        UIManager.GetInstance().OpenPanel("PausePanel", UITweenType.Scale, PauseGame);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void LoadData()
    {
        scorevalue = 0;
        score.text = "Score : 0";
    }

    public int GetScoreValue()
    {
        return Mathf.RoundToInt(scorevalue);
    }
}

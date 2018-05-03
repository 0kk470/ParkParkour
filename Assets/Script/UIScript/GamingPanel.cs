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
    private Text candyNum;
    private float scorevalue; //分数
    private int candyvalue; //拥有的糖果数量
    // Use this for initialization
    void Awake()
    {
        score = transform.Find("Score").GetComponent<Text>();
        candyNum = transform.Find("candy/Text").GetComponent<Text>();
        transform.Find("pause_btn").GetComponent<Button>().onClick.AddListener(OnPauseBtnClick);
    }

    void OnEnable()
    {
        LoadData();
        GameManager.GetInstance().OnPickItem += OnPick;
        candyvalue = DataManager.LoadData<int>("candy");
    }

    void OnDisable()
    {
        GameManager.GetInstance().OnPickItem -= OnPick;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.curState != GameState.Gaming)
            return;
        UpdateScore();
    }

    void UpdateScore()
    {
        scorevalue += Time.deltaTime * 10;
        score.text = "Score : " + Mathf.Ceil(scorevalue);
        candyNum.text = candyvalue.ToString();
    }

    private void OnPauseBtnClick()
    {
        UIManager.GetInstance().OpenPanel("PausePanel", UITweenType.Scale, PauseGame);
    }

    private void OnPick(object sender,EventArgs e)
    {
        var pue = e as PickUpEventArgs;
        if(pue == null)
        {
            Debug.LogError("获取拾取信息失败");
            return;
        }
        scorevalue += pue.pickScore;
        switch (pue.pickType)
        {
            case pickUpType.candy:
                {
                    PickCandy();
                    break;
                }
            default:
                break;
        }
    }


    private void PickCandy()
    {
        candyvalue += 1;
        DataManager.SaveData("candy", candyvalue);
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

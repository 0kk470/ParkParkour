using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverPanel : MonoBehaviour,UIBase {
    private Text Score;
    private Button uploadbtn;
    void Awake()
    {
        Score = transform.Find("score").GetComponent<Text>();
        transform.Find("restart_btn").GetComponent<Button>().onClick.AddListener(OnRestartBtnClick);
        transform.Find("back_btn").GetComponent<Button>().onClick.AddListener(OnBackBtnClick);
        uploadbtn = transform.Find("upload_btn").GetComponent<Button>();
        uploadbtn.onClick.AddListener(OnUploadBtnClick);
    }
    void OnEnable()
    {
        LoadData();
        uploadbtn.interactable = true;
    }

    void OnRestartBtnClick()
    {
        GameManager.GetInstance().RestartGame();
    }

    void OnBackBtnClick()
    {
        Debug.Log("重新加载");
        ResumeGame();
        SceneManager.LoadScene(0);
        GameManager.curState = GameState.GameStart;
    }

    void OnUploadBtnClick()
    {
        UIManager.GetInstance().ShowMessageBox(new MessageBoxData("输入名字上传你的分数",UploadScore,MessageBoxType.INPUT));
    }

    void UploadScore()
    {
        StartCoroutine(UploadScoreProcess());
        uploadbtn.interactable = false;
    }

    private IEnumerator UploadScoreProcess()
    {
        string playerName = UIManager.GetInstance().mb.GetInput();
        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "未知玩家";
        }
        int score = DataManager.LoadData<int>("Score");
        PlayerData myscore = new PlayerData();
        myscore.PlayerName = playerName;
        myscore.Score = score;
        var wait = myscore.SaveAsync();
        while (!wait.IsCompleted)
        {
            if (wait.IsFaulted || wait.IsCanceled)
                yield break;
            else
                yield return null;
        }
        UIManager.GetInstance().OpenPanel("RankPanel", UITweenType.Scale);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void LoadData()
    {
        Score.text = DataManager.LoadData<int>("Score").ToString();
    }
}

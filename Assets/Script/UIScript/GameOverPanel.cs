using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverPanel : MonoBehaviour,UIBase {
    private Text Score;
    void Awake()
    {
        Score = transform.Find("score").GetComponent<Text>();
        transform.Find("restart_btn").GetComponent<Button>().onClick.AddListener(OnRestartBtnClick);
        transform.Find("back_btn").GetComponent<Button>().onClick.AddListener(OnBackBtnClick);
        transform.Find("upload_btn").GetComponent<Button>().onClick.AddListener(OnUploadBtnClick);
    }
    void OnEnable()
    {
        LoadData();
    }

    void OnRestartBtnClick()
    {

    }

    void OnBackBtnClick()
    {
        Debug.Log("重新加载");
        ResumeGame();
        SceneManager.LoadScene(0);
    }

    void OnUploadBtnClick()
    {

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

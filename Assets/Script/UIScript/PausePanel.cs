using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour, UIBase
{
    public void LoadData()
    {
    }

    void OnEnable()
    {
        LoadData();
    }
    // Use this for initialization
    void Awake ()
    {
        transform.Find("restart_btn").GetComponent<Button>().onClick.AddListener(OnRestartBtnClick);
        transform.Find("back_btn").GetComponent<Button>().onClick.AddListener(OnBackBtnClick);
        transform.Find("resume_btn").GetComponent<Button>().onClick.AddListener(OnResumeBtnClick);
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

    void OnResumeBtnClick()
    {
        Debug.Log("返回游戏");
        UIManager.GetInstance().ClosePanel("PausePanel", UITweenType.Scale,ResumeGame);
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

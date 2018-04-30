using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.Events;
/// <summary>
/// 单例UI管理类
/// </summary>
public enum UITweenType
{
    Scale,
    Fade,
}

public interface UIBase
{
    void LoadData();
}

public class UIManager : MonoBehaviour {
    private static UIManager instance;
    private Dictionary<string, Transform> UIObjects;
    // Use this for initialization

    void Start ()
    {
        DOTween.Init();
        DOTween.defaultTimeScaleIndependent = true;
        GameManager.GetInstance().OnGameOver += GameOver;
        GameManager.GetInstance().OnGameStart += GameStart;
        instance = this;
        UIObjects = new Dictionary<string, Transform>();
        UIObjects["StartPanel"] = transform.Find("StartPanel");
        UIObjects["SkillPanel"] = transform.Find("SkillPanel");
        UIObjects["GamingPanel"] = transform.Find("GamingPanel");
        UIObjects["GameOverPanel"] = transform.Find("GameOverPanel");
        UIObjects["RankPanel"] = transform.Find("RankPanel");
        UIObjects["SettingPanel"] = transform.Find("SettingPanel");
        UIObjects["PausePanel"] = transform.Find("PausePanel");
        InitPanel();
    }
	

    public static UIManager GetInstance()
    {
        if (instance == null)
            Debug.LogError("UIManager instance not initialized!");
        return instance;
    }

    public void InitPanel()
    {
        for(int i = 0;i < transform.childCount;i++)
        {
            var panel = transform.GetChild(i);
            if (panel.gameObject.name == "StartPanel")
            {
                panel.gameObject.SetActive(true);
                panel.localScale = Vector3.one;
            }
            else
            {
                if (panel.gameObject.activeInHierarchy)
                    panel.gameObject.SetActive(false);
            }
        }
    }

    public void ClosePanel(string name, UITweenType type,TweenCallback callback = null)
    {
        switch (type)
        {
            case UITweenType.Scale:
                UIObjects[name].DOScale(0, 0.1f).onComplete = callback + (() => { UIObjects[name].gameObject.SetActive(false); });
                break;
            case UITweenType.Fade:
                UIObjects[name].GetComponent<CanvasGroup>().DOFade(0, 1f).onComplete = () => { UIObjects[name].gameObject.SetActive(false); };
                break;
        }
    }

    public void OpenPanel(string name, UITweenType type, TweenCallback callback = null)
    {
        UIObjects[name].gameObject.SetActive(true);
        switch (type)
        {
            case UITweenType.Scale:
                UIObjects[name].DOScale(1, 0.1f).onComplete = callback;
                break;
            case UITweenType.Fade:
                UIObjects[name].GetComponent<CanvasGroup>().DOFade(1, 1f).onComplete = callback;
                break;
        }
    }

    void GameOver(object sender, EventArgs e)
    {
        StartCoroutine(UIGameOverProcess());
    }

    private IEnumerator UIGameOverProcess()
    {
        ClosePanel("GamingPanel", UITweenType.Fade);
        yield return new WaitForSeconds(2f);
        OpenPanel("GameOverPanel", UITweenType.Scale);
        yield return new WaitForSeconds(1f);
    }

    void GameStart(object sender,EventArgs e)
    {
        StartCoroutine(UIGameStartProcess());
    }

    private IEnumerator UIGameStartProcess()
    {
        ClosePanel("StartPanel", UITweenType.Fade);
        yield return new WaitForSeconds(0.1f);
        OpenPanel("GamingPanel", UITweenType.Fade);
    }
}

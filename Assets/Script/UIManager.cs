using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
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
            instance = new UIManager();
        return instance;
    }

    public void InitPanel()
    {
        for(int i = 0;i < transform.childCount;i++)
        {
            var panel = transform.GetChild(i);
            if (i == 0)
            {
                panel.localScale = Vector3.one;
            }
            else
            {
                panel.localScale = Vector3.zero;
            }
            if(!panel.gameObject.activeInHierarchy)
                panel.gameObject.SetActive(true);
        }
    }

    public void ClosePanel(string name, UITweenType type)
    {
        switch(type)
        {
            case UITweenType.Scale:
                UIObjects[name].DOScale(0, 0.1f);
                break;
            case UITweenType.Fade:
                UIObjects[name].GetComponent<CanvasGroup>().DOFade(0, 1f);
                break;
        }
    }

    public void OpenPanel(string name, UITweenType type)
    {
        UIObjects[name].gameObject.SetActive(true);
        switch (type)
        {
            case UITweenType.Scale:
                UIObjects[name].DOScale(1, 0.1f);
                break;
            case UITweenType.Fade:
                UIObjects[name].GetComponent<CanvasGroup>().DOFade(1, 1f);
                break;
        }
    }
}

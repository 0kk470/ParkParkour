using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例UI管理类
/// </summary>
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
            if(i == 0)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }

    public void ClosePanel(string name)
    {
        UIObjects[name].gameObject.SetActive(false);
    }

    public void OpenPanel(string name)
    {
        UIObjects[name].gameObject.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例UI管理类
/// </summary>
public class UIManager : MonoBehaviour {
    private static UIManager instance;
    private Transform StartPanel;
    private Transform SkillPanel;
    private Transform GamingPanel;
    private Transform GameOverPanel;
    private Transform RankPanel;
    private Transform SettingPanel;
    private Transform PausePanel;
    // Use this for initialization
    void Start ()
    {
        StartPanel = transform.Find("StartPanel");
        SkillPanel = transform.Find("SkillPanel");
        GamingPanel = transform.Find("GamingPanel");
        GameOverPanel = transform.Find("GameOverPanel");
        RankPanel = transform.Find("RankPanel");
        SettingPanel = transform.Find("SettingPanel");
        PausePanel = transform.Find("PausePanel");
        Init();
    }
	

    public UIManager GetInstance()
    {
        if (instance == null)
            instance = this;
        return instance;
    }

    public void Init()
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

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}

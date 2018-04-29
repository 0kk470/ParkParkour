using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingPanel : MonoBehaviour, UIBase
{

    void OnDestroy()
    {
        GameManager.GetInstance().OnGameStart -= Show;
    }
    // Use this for initialization
    void Start()
    {
        GameManager.GetInstance().OnGameStart += Show;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Show(object sender, System.EventArgs e)
    {
        Debug.Log("打开游戏中界面");
        UIManager.GetInstance().OpenPanel("GamingPanel", UITweenType.Fade);
    }

    public void LoadData()
    {
    }
}

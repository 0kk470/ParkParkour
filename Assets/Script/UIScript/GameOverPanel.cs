using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour,UIBase {

    void OnEnable()
    {
        LoadData();
    }
    // Use this for initialization
    void Start () {
        GameManager.GetInstance().OnGameOver += GameOver;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadData()
    {

    }

    void GameOver(object sender,EventArgs e)
    {
        LoadData();
        ShowPanel();
    }

    private  IEnumerator ShowPanel()
    {
        yield return new WaitForSeconds(2f);
        UIManager.GetInstance().OpenPanel("GameOverPanel", UITweenType.Scale);
    }
}

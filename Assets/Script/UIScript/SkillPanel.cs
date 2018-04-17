using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPanel : MonoBehaviour, UIBase
{
    void OnEnable()
    {
        LoadData();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCloseBtnClick()
    {
        UIManager.GetInstance().ClosePanel("SkillPanel", UITweenType.Scale);
    }

    public void LoadData()
    {
    }
}

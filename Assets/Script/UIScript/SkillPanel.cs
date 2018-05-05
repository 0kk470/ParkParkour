using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillPanel : MonoBehaviour, UIBase
{
    void OnEnable()
    {
        LoadData();
    }
    // Use this for initialization
    void Start () {
        transform.Find("close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
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

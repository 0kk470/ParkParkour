using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillPanel : MonoBehaviour, UIBase
{
    private Slider powervalue;
    private Text Money;
    void OnEnable()
    {
        LoadData();
    }
    // Use this for initialization
    void Awake () {
        transform.Find("close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
        transform.Find("JumpSkill/addBtn").GetComponent<Button>().onClick.AddListener(OnAddPorintBtnClick);
        Money = transform.Find("money").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCloseBtnClick()
    {
        UIManager.GetInstance().ClosePanel("SkillPanel", UITweenType.Scale);
    }

    void OnAddPorintBtnClick()
    {
       UIManager.GetInstance().ShowMessageBox(new MessageBoxData("你的糖果数量不足"));
    }

    public void LoadData()
    {
        Money.text = DataManager.LoadData<int>("candy").ToString();
    }
}

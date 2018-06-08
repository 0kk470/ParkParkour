using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class StartPanel : MonoBehaviour,IPointerClickHandler, UIBase
{
    private Text StartText;
    private Transform Title;
    void OnEnable()
    {
        LoadData();
    }
    // Use this for initialization

    void Start ()
    {
        Init();
    }

    void Init()
    {
        Title = transform.Find("Title");
        StartText = transform.Find("Note").GetComponent<Text>();
        transform.Find("setting_btn").GetComponent<Button>().onClick.AddListener(OnSettingBtnClick);
        transform.Find("rank_btn").GetComponent<Button>().onClick.AddListener(OnRankBtnClick);
        transform.Find("item_btn").GetComponent<Button>().onClick.AddListener(OnItemBtnClick);

        StartText.DOFade(0, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        Title.DOMoveY(1.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void OnSettingBtnClick()
    {
        UIManager.GetInstance().OpenPanel("SettingPanel", UITweenType.Scale);
    }

    private void OnRankBtnClick()
    {
        UIManager.GetInstance().OpenPanel("RankPanel", UITweenType.Scale);
    }

    private void OnItemBtnClick()
    {
        UIManager.GetInstance().OpenPanel("SkillPanel", UITweenType.Scale);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerPress.name == gameObject.name && GameManager.curState == GameState.GameStart)
        {
            Debug.Log("点击开始界面");
            UIManager.GetInstance().ClosePanel("StartPanel", UITweenType.Fade);
            GameManager.GetInstance().StartGame(this,EventArgs.Empty);
        }
    }

    public void LoadData()
    {
    }
}

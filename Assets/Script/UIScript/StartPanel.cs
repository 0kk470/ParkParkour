using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class StartPanel : MonoBehaviour,IPointerClickHandler{

	// Use this for initialization
	void Start ()
    {
        transform.Find("setting_btn").GetComponent<Button>().onClick.AddListener(OnSettingBtnClick);
        transform.Find("rank_btn").GetComponent<Button>().onClick.AddListener(OnRankBtnClick);
        transform.Find("item_btn").GetComponent<Button>().onClick.AddListener(OnItemBtnClick);
    }

    private void OnSettingBtnClick()
    {
        UIManager.GetInstance().OpenPanel("SettingPanel");
    }

    private void OnRankBtnClick()
    {
        UIManager.GetInstance().OpenPanel("RankPanel");
    }

    private void OnItemBtnClick()
    {
        UIManager.GetInstance().OpenPanel("SkillPanel");
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        if(eventData.pointerPress.name == gameObject.name && GameManager.curState == GameState.GameStart)
        {
            Debug.Log("游戏开始！");
        }
    }
}

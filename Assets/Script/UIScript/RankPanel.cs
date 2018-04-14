using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankPanel : MonoBehaviour {
    private Button RefreshBtn;
    private Button CloseBtn;
	// Use this for initialization
	void Start ()
    {
        transform.Find("bg/close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
        RefreshBtn = transform.Find("bg/refresh_btn").GetComponent<Button>();
        RefreshBtn.onClick.AddListener(OnRefreshBtnClick);
    }

    private void OnCloseBtnClick()
    {
        UIManager.GetInstance().ClosePanel(gameObject.name, UITweenType.Scale);
    }

    private void OnRefreshBtnClick()
    {
        StartCoroutine(RefreshData());
    }

    private IEnumerator RefreshData()
    {
        RefreshBtn.interactable = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("Refresh data..");
        RefreshBtn.interactable = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankPanel : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        transform.Find("bg/close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
	}
	
	private void OnCloseBtnClick()
    {
        UIManager.GetInstance().ClosePanel(gameObject.name);
    }
}

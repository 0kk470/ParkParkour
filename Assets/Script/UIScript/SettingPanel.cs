using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour {
    private GameObject makerNameList;
	// Use this for initialization
	void Start ()
    {
        transform.Find("close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
        transform.Find("makername").GetComponent<Toggle>().onValueChanged.AddListener(OnMakerValueChanged);
        transform.Find("music_tog").GetComponent<Toggle>().onValueChanged.AddListener(OnMusicValueChanged);
        transform.Find("audio_tog").GetComponent<Toggle>().onValueChanged.AddListener(OnAudioValueChanged);
        makerNameList = transform.Find("nameList").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCloseBtnClick()
    {
        UIManager.GetInstance().ClosePanel(gameObject.name);
    }

    private void OnMakerValueChanged(bool check)
    {
        makerNameList.SetActive(check);
    }

    private void OnMusicValueChanged(bool check)
    {
        Debug.Log("音乐:" + check);
    }

    private void OnAudioValueChanged(bool check)
    {
        Debug.Log("音效:" + check);
    }
}

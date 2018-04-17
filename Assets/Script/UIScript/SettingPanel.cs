using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour, UIBase
{
    [SerializeField]
    private Transform makerNameList;
    // Use this for initialization

    void OnEnable()
    {
        LoadData();
    }
    void Start ()
    {
        makerNameList = transform.Find("nameList");
        transform.Find("close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
        transform.Find("makername").GetComponent<Toggle>().onValueChanged.AddListener(OnMakerValueChanged);
        transform.Find("music_tog").GetComponent<Toggle>().onValueChanged.AddListener(OnMusicValueChanged);
        transform.Find("audio_tog").GetComponent<Toggle>().onValueChanged.AddListener(OnAudioValueChanged);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCloseBtnClick()
    {
        UIManager.GetInstance().ClosePanel(gameObject.name, UITweenType.Scale);
    }

    private void OnMakerValueChanged(bool check)
    {
        if(makerNameList != null)
          makerNameList.gameObject.SetActive(check);

    }

    private void OnMusicValueChanged(bool check)
    {
        Debug.Log("音乐:" + check);
    }

    private void OnAudioValueChanged(bool check)
    {
        Debug.Log("音效:" + check);
    }

    public void LoadData()
    {
    }
}

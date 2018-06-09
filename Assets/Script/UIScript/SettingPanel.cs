using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour, UIBase
{
    [SerializeField]
    private Transform makerNameList;
    // Use this for initialization
    private Toggle audiotog;
    private Toggle musictog;

    void Awake ()
    {
        makerNameList = transform.Find("nameList");
        transform.Find("close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
        transform.Find("makername").GetComponent<Toggle>().onValueChanged.AddListener(OnMakerValueChanged);
        musictog = transform.Find("music_tog").GetComponent<Toggle>();
        musictog.onValueChanged.AddListener(OnMusicValueChanged);
        audiotog = transform.Find("audio_tog").GetComponent<Toggle>();
        audiotog.onValueChanged.AddListener(OnAudioValueChanged);
    }

    void OnEnable()
    {
        LoadData();
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
        AudioManager.instance.SetMusic(check);
        Debug.Log("音乐:" + check);
    }

    private void OnAudioValueChanged(bool check)
    {
        AudioManager.SetVolume(check);
        Debug.Log("音效:" + check);
    }

    public void LoadData()
    {
        audiotog.isOn = DataManager.LoadData<int>(KeyConfig.Audio) == 1;
        musictog.isOn = DataManager.LoadData<int>(KeyConfig.Music) == 1;
        Debug.Log("加载数据");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public enum MessageBoxType
{
    NORMAL = 0,
    INPUT = 1
}
public class MessageBoxData
{
    public UnityAction BtnCallBack;
    public string notice;
    public string BtnName;
    public MessageBoxType type;
    public MessageBoxData(string _notice, UnityAction callback = null,MessageBoxType _type = MessageBoxType.NORMAL)
    {
        BtnCallBack = callback;
        notice = _notice;
        type = _type;
    }
}

public class MessageBox : MonoBehaviour {

    private Text Notice;
    private InputField input;
    private MessageBoxData currentData;
	// Use this for initialization
	void Start ()
    {
        Notice = transform.Find("Main/notice").GetComponent<Text>();
        transform.Find("Main/FirstBtn").GetComponent<Button>().onClick.AddListener(OnFirstBtnClick);
        input = transform.Find("Main/InputField").GetComponent<InputField>();
    }
	

    void OnFirstBtnClick()
    {
        if (currentData.BtnCallBack != null)
            currentData.BtnCallBack();
        transform.DOScale(Vector3.zero, 0.2f).onComplete = () => { currentData = null;
                                                                   input.text = "";
                                                                   input.gameObject.SetActive(false);
                                                                  };
    }

    public void Show(MessageBoxData boxData = null)
    {
        currentData = boxData;
        if (currentData.type == MessageBoxType.INPUT)
            input.gameObject.SetActive(true);
        gameObject.SetActive(true);
        Notice.text = currentData.notice;
        transform.DOScale(Vector3.one, 0.2f);
    }

    public string GetInput()
    {
        return input.text;
    }
}

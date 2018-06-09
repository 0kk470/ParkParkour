using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEventArgs : EventArgs
{

}

public class GamingPanel : MonoBehaviour, UIBase
{
    private Text score;
    private Text candyNum;
    private Text ShieldNum;
    private Text RayNum;
    private Text ShieldTimerText;
    private Text RayTimerText;
    private float scorevalue; //分数
    private int candyvalue; //拥有的糖果数量
    private int ShieldValue;
    private int RayValue;
    private float RayCoolDown;
    private float ShieldCoolDown;
    private Button RayButton;
    private Button ShieldButton;
    // Use this for initialization
    void Awake()
    {
        score = transform.Find("Score").GetComponent<Text>();
        candyNum = transform.Find("candy/Text").GetComponent<Text>();
        ShieldNum = transform.Find("shield_btn/num").GetComponent<Text>();
        RayNum = transform.Find("ray_btn/num").GetComponent<Text>();
        ShieldTimerText = transform.Find("shield_btn/cooldown").GetComponent<Text>();
        RayTimerText = transform.Find("ray_btn/cooldown").GetComponent<Text>();
        transform.Find("pause_btn").GetComponent<Button>().onClick.AddListener(OnPauseBtnClick);
        RayButton = transform.Find("ray_btn").GetComponent<Button>();
        ShieldButton = transform.Find("shield_btn").GetComponent<Button>();
        RayButton.onClick.AddListener(OnRayBtnClick);
        ShieldButton.onClick.AddListener(OnShieldBtnClick);
    }

    void OnEnable()
    {
        LoadData();
        GameManager.GetInstance().OnPickItem += OnPick;
    }

    void OnDisable()
    {
        GameManager.GetInstance().OnPickItem -= OnPick;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.curState != GameState.Gaming)
        {
            if (scorevalue != 0 && GameManager.curState == GameState.GameStart)
                scorevalue = 0;
            return;
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        scorevalue += Time.deltaTime * 10;
        score.text = "Score : " + Mathf.Ceil(scorevalue);
        candyNum.text = candyvalue.ToString();
    }

    private void OnPauseBtnClick()
    {
        UIManager.GetInstance().OpenPanel("PausePanel", UITweenType.Scale, PauseGame);
    }

    void CheckItemNum()
    {
        if (RayValue < 1)
            RayButton.interactable = false;
        else
            RayButton.interactable = true;
        if (ShieldValue < 1)
            ShieldButton.interactable = false;
        else
            ShieldButton.interactable = true;
    }

    private void OnRayBtnClick()
    {
        RayButton.interactable = false;
        GameManager.GetInstance().SetRay(true);
        DataManager.SaveData(KeyConfig.ray, --RayValue);
        RayNum.text = RayValue.ToString();
        RayCoolDown = 20f;
        RayTimerText.gameObject.SetActive(true);
        StartCoroutine(RayTimer());
    }

    private IEnumerator RayTimer()
    {
        while(RayCoolDown >= 0.1f)
        {
            RayCoolDown -= Time.deltaTime;
            RayTimerText.text = Mathf.Ceil(RayCoolDown).ToString();
            yield return null;
        }
        RayTimerText.gameObject.SetActive(false);
        CheckItemNum();
    }

    private void OnShieldBtnClick()
    {
        ShieldButton.interactable = false;
        GameManager.GetInstance().SetShield(true);
        DataManager.SaveData(KeyConfig.shield, --ShieldValue);
        ShieldNum.text = ShieldValue.ToString();
        ShieldCoolDown = 12f;
        ShieldTimerText.gameObject.SetActive(true);
        StartCoroutine(ShieldTimer());
    }

    private IEnumerator ShieldTimer()
    {
        while (ShieldCoolDown >= 0.1f)
        {
            ShieldCoolDown -= Time.deltaTime;
            ShieldTimerText.text = Mathf.Ceil(ShieldCoolDown).ToString();
            yield return null;
        }
        ShieldTimerText.gameObject.SetActive(false);
        CheckItemNum();
    }

    private void OnPick(object sender,EventArgs e)
    {
        var pue = e as PickUpEventArgs;
        if(pue == null)
        {
            Debug.LogError("获取拾取信息失败");
            return;
        }
        scorevalue += pue.pickScore;
        switch (pue.pickType)
        {
            case pickUpType.candy:
                {
                    PickCandy();
                    break;
                }
            default:
                break;
        }
    }


    private void PickCandy()
    {
        candyvalue += 1;
        DataManager.SaveData("candy", candyvalue);
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void LoadData()
    {
        scorevalue = 0;
        score.text = "Score : 0";
        candyvalue = DataManager.LoadData<int>("candy");
        RayValue = DataManager.LoadData<int>(KeyConfig.ray);
        ShieldValue = DataManager.LoadData<int>(KeyConfig.shield);
        RayNum.text = RayValue.ToString();
        ShieldNum.text = ShieldValue.ToString();
        ShieldTimerText.gameObject.SetActive(false);
        RayTimerText.gameObject.SetActive(false);
        CheckItemNum();
    }

    public int GetScoreValue()
    {
        return Mathf.RoundToInt(scorevalue);
    }

}

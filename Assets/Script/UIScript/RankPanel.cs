using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LeanCloud;
using LeanCloud.Storage.Internal;

public class RankPanel : MonoBehaviour, UIBase
{
    private Button RefreshBtn;
    private Button CloseBtn;
    private ScrollRect rankList;
    private Transform rankLabel;
    private List<PlayerData> rankdata;
    // Use this for initialization
    void Awake()
    {
        rankdata = new List<PlayerData>();
        rankList = transform.Find("scroll_list").GetComponent<ScrollRect>();
        rankLabel = rankList.content.GetChild(0);
        transform.Find("bg/close_btn").GetComponent<Button>().onClick.AddListener(OnCloseBtnClick);
        RefreshBtn = transform.Find("bg/refresh_btn").GetComponent<Button>();
        RefreshBtn.onClick.AddListener(OnRefreshBtnClick);
    }

    void OnEnable()
    {
        LoadData();
    }

    private void OnCloseBtnClick()
    {
        UIManager.GetInstance().ClosePanel(gameObject.name, UITweenType.Scale);
    }

    private void OnRefreshBtnClick()
    {
        LoadData();
    }

    public Transform AddLabel()
    {
        var trans = Instantiate(rankLabel);
        trans.SetParent(rankList.content);
        trans.localScale = Vector3.one;
        return trans;
    }

    public void LoadData()
    {
        rankdata.Clear();
        RemoveLabel();
        StartCoroutine(queryRank());
    }

    public void RemoveLabel()
    {
        for(int i = 1;i < rankList.content.childCount;i++)
        {
            Destroy(rankList.content.GetChild(i).gameObject);
        }
    }

    void OnLoadComplete()
    {
        Debug.Log("加载完成");
        for (int i = 0; i < rankdata.Count; i++)
        {
            var label = AddLabel();
            if (label == null)
                Debug.LogError("加载Label实体出错");
            label.Find("name").GetComponent<Text>().text = rankdata[i].PlayerName;
            label.Find("score").GetComponent<Text>().text = rankdata[i].Score.ToString();
            label.Find("rank").GetComponent<Text>().text = (i + 1).ToString();
            label.gameObject.SetActive(true);
        }
    }


    private IEnumerator queryRank()
    {
        RefreshBtn.interactable = false;
        var query = new AVQuery<PlayerData>().OrderByDescending("score").Limit(100).FindAsync().ContinueWith(t =>
        {
            foreach (var data in t.Result)
            {
                Debug.Log(data.PlayerName + " : " + data.Score);
                rankdata.Add(data);
            }
        });
        while (!query.IsCompleted)
            yield return null;
        OnLoadComplete();
        Debug.Log("Refresh data..");
        RefreshBtn.interactable = true;
    }
}

using LeanCloud;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// 游戏初始化类
/// </summary>
public class Initializer : MonoBehaviour {

    private void Awake()
    {
        AVObject.RegisterSubclass<PlayerData>();
        int firstLaunch = PlayerPrefs.GetInt("launch");
        if(firstLaunch == 0)
        {
            Debug.Log("第一次启动游戏");
            PlayerPrefs.SetInt("launch", 1);
            PlayerPrefs.Save();
            DataManager.InitData();
        }
    }
    // Use this for initialization
    void Start ()
    {
        //List<PlayerData> players = new List<PlayerData>(20);
        //LeanCloud Test Codes
        //Task save = gameScore.SaveAsync();
        /*查询测试完成
        AVQuery<AVObject> query = new AVQuery<AVObject>("PlayerData").WhereEqualTo("score", 1);
        query.FindAsync().ContinueWith(t =>
        {
            if(t.IsFaulted)
            {
                Debug.LogError("查询错误");
            }
            else
            {
                foreach (var item in t.Result)
                {
                    Debug.Log(item["playerName"] + " : " + item["score"]);
                }
            }
        }
         );
         */
    }

    // Update is called once per frame
    void Update () {
		
	}
}

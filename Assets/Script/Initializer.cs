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
        GameManager.Init();
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

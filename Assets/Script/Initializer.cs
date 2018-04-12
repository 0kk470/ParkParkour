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
        GameManager.Init();
    }
    // Use this for initialization
    void Start ()
    {
        //LeanCloud Test Codes
        AVObject gameScore = new AVObject("GameScore");
        gameScore["score"] = 1;
        gameScore["playerName"] = "KK";
        /*查询测试完成
        AVQuery<AVObject> query = new AVQuery<AVObject>("GameScore").WhereEqualTo("score", 1);
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

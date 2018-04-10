using LeanCloud;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// 游戏初始化类
/// </summary>
public class Initializer : MonoBehaviour {

    // Use this for initialization
    void Start ()
    {
        //LeanCloud Test Codes
        AVObject gameScore = new AVObject("GameScore");
        gameScore["score"] = 1;
        gameScore["playerName"] = "KK";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

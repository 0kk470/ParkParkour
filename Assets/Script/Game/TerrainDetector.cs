using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDetector : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("进入");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log(collision.gameObject.name + "进入触发区,准备生成新地形");
            TerranManager.GetInstance().SpawnTerranFromPool(TerranManager.GetInstance().RandomGenerateTile());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("离开");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("回收" + collision.gameObject.name);
            TerranManager.GetInstance().CollectTerranToPool(collision.GetComponent<TileBase>());
        }
    }

}

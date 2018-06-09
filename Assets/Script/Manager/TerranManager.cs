using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TileType
{
    SimpleTile = 0,
    NormalTile,
    HardTile,
}

public class TerranManager : MonoBehaviour {
    public Transform TerranStartPosition;
    public GameObject RestartTile;
    public List<PickUp> ItemList;
    public List<GameObject> ObstacleList;
    private static TerranManager instance;
    private GamingPanel gp;
    [SerializeField]
    private List<TileBase> ActivatedTiles;
    [SerializeField]
    private Dictionary<TileType, Queue<TileBase>> TilePool;
    //以下皆为随着游戏时间长短而变化的值，需要特殊的函数处理
    [SerializeField]
    private float TileSpeed = 5f;
    [SerializeField]
    private float simpleValue;
    [SerializeField]
    private float normalValue;
    [SerializeField]
    private float hardValue;
    [SerializeField]
    private int ItemNum = 10;
    [SerializeField]
    private int ObstacleNum = 3;
	// Use this for initialization
	void Awake ()
    {
        TilePool = new Dictionary<TileType, Queue<TileBase>>();
        TilePool.Add(TileType.SimpleTile, new Queue<TileBase>());
        TilePool.Add(TileType.NormalTile, new Queue<TileBase>());
        TilePool.Add(TileType.HardTile, new Queue<TileBase>());
        instance = this;
	}

    private void Start()
    {
        GameManager.GetInstance().OnGameOver += GameOver;
        gp = FindObjectOfType<GamingPanel>();
    }

    private void Update()
    {
        if (GameManager.curState != GameState.Gaming)
            return;
        CaculateValue();
    }

    private void CaculateValue()
    {
        simpleValue = 60 -  Mathf.Log10(gp.GetScoreValue() * 10 + 1);
        if (simpleValue < 20)
            simpleValue = 20;

        normalValue = 90 - Mathf.Log10(gp.GetScoreValue() * 5 + 1);
        if (normalValue < 40)
            normalValue = 40;
    }

    private GameObject CreateNewTerran(TileType _type)
    {
        string loadPath = null;
        switch (_type)
        {
            case TileType.SimpleTile:
                loadPath = "Prefab/Terran/SimpleTile";
                break;
            case TileType.NormalTile:
                loadPath = "Prefab/Terran/NormalTile";
                break;
            case TileType.HardTile:
                loadPath = "Prefab/Terran/HardTile";
                break;
        }
        if (string.IsNullOrEmpty(loadPath))
            Debug.LogError("加载路径错误");
        var obj = Instantiate(Resources.Load(loadPath) as GameObject);
        obj.SetActive(false);
        if (obj == null)
            Debug.LogError("加载地形prefab出错");
        return obj;
    }

    private void GameOver(object sender,System.EventArgs e)
    {
        StopRollingTerrain();
    }

    public void Init()
    {
        TileSpeed = 5f;
        ItemNum = 10;
        ObstacleNum = 2;
        simpleValue = 60;
        normalValue = 90;
        hardValue = 100;
        while(ActivatedTiles.Count > 0)
        {
            CollectTerranToPool(ActivatedTiles[0]);
        }
        var simp = Instantiate(RestartTile);
        ActivatedTiles.Add(simp.GetComponent<TileBase>());
        simp.transform.SetParent(transform);
        simp.transform.localPosition = RestartTile.transform.localPosition;
        simp.SetActive(true);
    }

    public static TerranManager GetInstance()
    {
        if (instance == null)
            Debug.LogError("TerranManager未初始化");
        return instance;
    }

	public void StartRollingTerran()
    {
        for(int i = 0;i < ActivatedTiles.Count;i++)
        {
            ActivatedTiles[i].SetSpeed(TileSpeed);
        }
    }

    public void StopRollingTerrain()
    {
        for (int i = 0; i < ActivatedTiles.Count; i++)
        {
            ActivatedTiles[i].SetSpeed(0);
        }
    }

    public TileType RandomGenerateTile()
    {
        TileType result = TileType.SimpleTile;
        float seed = Random.Range(0, hardValue);
        Debug.Log("种子数" + seed);
        if (seed <= simpleValue)
            result = TileType.SimpleTile;
        else if (seed > simpleValue && seed < normalValue)
            result = TileType.NormalTile;
        else
            result = TileType.HardTile;
        return result;

    }

    private void SpawnChilds(TileBase tile)
    {
        for(int i = 0;i < ItemNum;i++)
        {
            int index = Random.Range(0, ItemList.Count);
            var item = ItemList[index];
            tile.SpawnItem(item.gameObject, Random.Range(item.GetSpawnRange().x, item.GetSpawnRange().y));
        }
        for(int i = 0;i < ObstacleNum;i++)
        {
            int index = Random.Range(0, ObstacleList.Count);
            var obstacle = ObstacleList[index];
            tile.SpawnItem(obstacle,10f);
        }
    }

    public TileBase SpawnTerranFromPool(TileType _type)
    {
        GameObject tile = null;
        if (TilePool[_type].Count > 0)
            tile = TilePool[_type].Dequeue().gameObject;
        else
            tile = CreateNewTerran(_type);
        tile.transform.SetParent(transform);
        tile.transform.localPosition = TerranStartPosition.localPosition;
        var tilebase = tile.GetComponent<TileBase>();
        SpawnChilds(tilebase);
        tilebase.Init(_type, TileSpeed);
        ActivatedTiles.Add(tilebase);
        tile.SetActive(true);
        return tilebase;
    }

    public void CollectTerranToPool(TileBase collect)
    {
        ActivatedTiles.Remove(collect);
        if (TilePool[collect.GetTileType()].Count >= 2)
        {
            Destroy(collect.gameObject);
            return;
        }
        else
        {
            collect.gameObject.SetActive(false);
            collect.transform.SetParent(transform);
            TilePool[collect.GetTileType()].Enqueue(collect);
        }
    }
}

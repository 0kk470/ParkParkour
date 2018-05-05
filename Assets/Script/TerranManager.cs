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
    private static TerranManager instance;
    [SerializeField]
    private Dictionary<TileType, Queue<TileBase>> TilePool;
    [SerializeField]
    private float TileSpeed = 5f;
    [SerializeField]
    private List<TileBase> ActivatedTiles;
    private GamingPanel gamingPanel;
    [SerializeField]
    private float simpleValue;
    [SerializeField]
    private float normalValue;
    [SerializeField]
    private float hardValue;
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
        gamingPanel = FindObjectOfType<GamingPanel>();
        GameManager.GetInstance().OnGameOver += GameOver;
    }

    private void Update()
    {
        int score = gamingPanel.GetScoreValue();
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

    public void SpawnTerranFromPool(TileType _type)
    {
        GameObject tile = null;
        if (TilePool[_type].Count > 0)
            tile = TilePool[_type].Dequeue().gameObject;
        else
            tile = CreateNewTerran(_type);
        tile.transform.SetParent(transform);
        tile.transform.localPosition = TerranStartPosition.localPosition;
        var tilebase = tile.GetComponent<TileBase>();
        tilebase.Init(_type, TileSpeed);
        ActivatedTiles.Add(tilebase);
        tile.SetActive(true);
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

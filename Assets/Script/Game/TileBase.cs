using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour {
    [SerializeField]
    protected TileType tileType;
    [SerializeField]
    protected float m_Speed;
	// Use this for initialization
	protected virtual void  Start ()
    {

    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        transform.position += Vector3.left * m_Speed * Time.deltaTime; 
	}

    void OnDisable()
    {
        DestroyChildren();
    }

    public virtual void DestroyChildren()
    {
        for(int i = 0;i < transform.childCount;i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    public virtual void SetSpeed(float _Speed)
    {
        m_Speed = _Speed;
    }

    public virtual void Init(TileType _type,float _Speed)
    {
        SetTileType(_type);
        SetSpeed(_Speed);
    }

    public float GetSpeed()
    {
        return m_Speed;
    }

    public void SetTileType(TileType _type)
    {
        tileType = _type;
    }

    public TileType GetTileType()
    {
        return tileType;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : MonoBehaviour {
    public float Setting_Speed;
    protected float m_Speed;
	// Use this for initialization
	protected virtual void  Start ()
    {
        SetSpeed(Setting_Speed);

    }
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        transform.position += Vector3.left * m_Speed * Time.deltaTime; 
	}

    public virtual void SetSpeed(float _Speed)
    {
        m_Speed = _Speed;
    }

    public float GetSpeed()
    {
        return m_Speed;
    }

    void OnBecameInvisible()
    {
        Debug.Log("不可见了");
        Destroy(gameObject);
    }



}

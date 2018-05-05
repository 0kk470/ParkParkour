using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;


public enum pickUpType
{
    candy = 0,
}

public class PickUpEventArgs : EventArgs
{
    public pickUpType pickType;
    public float pickScore;
    public PickUpEventArgs(pickUpType _picktype,float _score)
    {
        pickType = _picktype;
        pickScore = _score;
    }
}

public class PickUp : MonoBehaviour {
    [SerializeField]
    protected float ItemScore;
    protected Transform startPosition;
	// Use this for initialization
	void Start () 
    {
        startPosition = transform;
        Animate();
    }
    // Update is called once per frame
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnter(collision);
    }

    protected void OnBecameInvisible()
    {
        OnInvisible();
    }

    protected virtual void Animate()
    {
        transform.DOMoveY(startPosition.position.y + 0.2f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear).SetUpdate(false);
    }

    protected virtual void OnInvisible()
    {
       
    }

    protected virtual void OnEnter(Collider2D collision)
    {

    }

    protected virtual void OnPick(object sender,EventArgs e)
    {

    }
}

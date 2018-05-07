using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour {
	// Use this for initialization
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.GetInstance().EndGame(collision.transform, EventArgs.Empty);
        }
    }


    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.GetInstance().EndGame(collision.transform, EventArgs.Empty);
        }
    }
}

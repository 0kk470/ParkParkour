using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   

public class Candy : PickUp {

    protected override void OnEnter(Collider2D collision)
    {
        base.OnEnter(collision);
        if(collision.CompareTag("Player"))
        {
            GameManager.GetInstance().PickItem(this,new PickUpEventArgs(pickUpType.candy,ItemScore));
        }
    }
    // Use this for initialization
}

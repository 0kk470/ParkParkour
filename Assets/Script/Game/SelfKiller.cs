using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfKiller : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            var me = transform.parent.GetComponent<Roach>();
            me.OnDeath();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundDetect : MonoBehaviour {
    Player player;
	// Use this for initialization
	void Start ()
    {
        player = FindObjectOfType<Player>();
	}

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("layer" + LayerMask.NameToLayer("Ground"));
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            player.SetState(PlayerState.Run);

        }
    }
}

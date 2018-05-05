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
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("地面");
            if(player.GetPlayerState() != PlayerState.Idle)
              player.SetState(PlayerState.Run);
        }
    }
}

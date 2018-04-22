using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {
    public float speed;
    public float jumpforce;
    protected Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void Move(float _speed)
    {

    }

    public virtual void Jump(float _jumpforce)
    {
        rb2d.AddForce(Vector2.up * _jumpforce);
    }
}

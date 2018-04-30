using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {
    public float speed;
    public float jumpforce;
    protected Rigidbody2D rb2d;
    protected Animator animator;
	// Use this for initialization
    public virtual void Move(float _speed)
    {

    }

    public virtual void Jump(float _jumpforce)
    {
        Debug.Log("跳跃力:" + _jumpforce);
        //注意将y方向速度清0，因为OnGroundDetect脚本在距离地面很小一段距离时就判断可以重新跳了，但这个时候下落速度还不为0且重力仍为被地面缓冲抵消，所以AddForce的力会被重力抵消
        rb2d.velocity = rb2d.velocity.x * Vector2.right;
        rb2d.AddRelativeForce(Vector2.up * _jumpforce);
    }
}

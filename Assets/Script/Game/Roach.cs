using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roach : CharacterBase
{
    [SerializeField]
    private GameObject body;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Init();
    }
	
	void Init()
    {
        
    }

    private void OnBecameVisible()
    {
        rb2d.velocity = Vector2.left * speed;
    }
    public void OnDeath()
    {
        StartCoroutine(DeathProcess());
    }

    public IEnumerator DeathProcess()
    {
        AudioManager.PlayAudio(GetComponent<AudioSource>());
        rb2d.isKinematic = true;
        animator.SetTrigger("death");
        Destroy(body);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

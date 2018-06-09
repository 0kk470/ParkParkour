using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRay : MonoBehaviour {



    private void OnEnable()
    {
        StartCoroutine(Timer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            Debug.Log(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(7f);
        gameObject.SetActive(false);
    }
}

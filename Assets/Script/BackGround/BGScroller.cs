using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {
    public float Destination;
    public float direction;
    [SerializeField]
    private float scrollSpeed;
    private Vector3 startPosition;
    private float offset;
	// Use this for initialization
	void Start ()
    {
        startPosition = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        Scroll();
	}

    protected virtual void Scroll()
    {
        offset = direction * Mathf.Repeat(scrollSpeed * Time.time, Destination);
        //Debug.Log(offset);
        transform.localPosition = startPosition + offset * Vector3.right;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
    private static UIManager instance;

    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public UIManager GetInstance()
    {
        if (instance == null)
            instance = this;
        return instance;
    }
}

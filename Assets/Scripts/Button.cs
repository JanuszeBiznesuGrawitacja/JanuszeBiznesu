﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    [SerializeField] Pipe pipe;

    public bool button1 = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pipe.Slide = true;
        StartCoroutine(stopMoving());
    }

    IEnumerator stopMoving()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<Rigidbody2D>().simulated = false;

    }

}

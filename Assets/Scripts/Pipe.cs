using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

    [SerializeField] float slideSpeed = 1f;
    [SerializeField] float endSlideY;

    private bool slide = false;

    public bool Slide
    {
        set { slide = value; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    	if(slide && transform.position.y > endSlideY)
        {
            transform.position = transform.position + Vector3.down * slideSpeed * Time.deltaTime;
        }
	}
}

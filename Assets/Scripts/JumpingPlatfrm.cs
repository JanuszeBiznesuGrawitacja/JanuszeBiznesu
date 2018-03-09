using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatfrm : MonoBehaviour {

    [SerializeField] float relativeVelocityToBreak = 1f;

    [SerializeField] GameObject ourPipe;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude >= relativeVelocityToBreak)
        {
            print("wdwdwdwd");
            Destroy(ourPipe);
        }
    }
}

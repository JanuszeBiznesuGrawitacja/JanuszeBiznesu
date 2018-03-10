using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatfrm : MonoBehaviour {

    [SerializeField] float relativeVelocityToBreak = 1f;

    [SerializeField] GameObject ourPipe;

    public GameObject pieceBoard;
    public Transform spawnPoint, spawnPoint1;

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
            Instantiate(pieceBoard, spawnPoint.position, Quaternion.identity);
            Instantiate(pieceBoard, spawnPoint1.position, Quaternion.identity);
            Destroy(ourPipe);
        }
    }
}

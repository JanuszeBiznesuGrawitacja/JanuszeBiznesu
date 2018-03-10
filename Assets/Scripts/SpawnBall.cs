using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {

    public GameObject ball;
    public Transform spawnPoint;
    GameObject currentBall;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if(currentBall==null)
        {
            Spawn();
        }
    }

    void Spawn()
    {
         currentBall = Instantiate(ball, spawnPoint.position, Quaternion.identity) as GameObject;
    }

}

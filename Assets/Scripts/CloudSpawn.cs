using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {

    [SerializeField] Transform spawnPoint;
    public Cloud[] cloud;

    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            Instantiate(cloud[Random.Range(0, cloud.Length - 1)], new Vector2(Random.Range(spawnPoint.position.x-2,spawnPoint.position.x+2), Random.Range(spawnPoint.position.y - 2, spawnPoint.position.y + 2)), Quaternion.identity);
            yield return new WaitForSeconds(1.5f);
        }
    }

}

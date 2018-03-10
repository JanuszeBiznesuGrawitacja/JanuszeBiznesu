using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.AddComponent<Rigidbody2D>();
    }


}

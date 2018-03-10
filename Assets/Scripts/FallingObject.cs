using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameObject.GetComponent<Rigidbody2D>())
        {
            Rigidbody2D rigidbody = gameObject.AddComponent<Rigidbody2D>();
            rigidbody.freezeRotation = true;
        }
    }


}

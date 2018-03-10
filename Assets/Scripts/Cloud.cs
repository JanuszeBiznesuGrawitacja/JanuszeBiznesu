using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Cloud : MonoBehaviour {

    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 0;
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(Random.Range(0.5f, 2.5f), rb2d.velocity.y);
    }


}

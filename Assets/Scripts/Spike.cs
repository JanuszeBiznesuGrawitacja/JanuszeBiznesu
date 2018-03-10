using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.Die();
        }
    }
}

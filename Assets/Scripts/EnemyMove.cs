using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMove : MonoBehaviour {

    public float speed;
    Rigidbody2D rb2d;
    public float relativeVelocityToKill;

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate () {
        rb2d.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude >= relativeVelocityToKill && collision.collider.tag == "Player")
        {
            transform.DOScaleY(0, 0.5f).OnComplete(() => Destroy(gameObject));
        }
        else
        {
            var health = collision.collider.GetComponentInParent<Health>();
            if (health != null)
            {
                health.LoseHealth(80, true);
            }
        }

    }
}

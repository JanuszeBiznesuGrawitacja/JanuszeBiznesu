using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    Rigidbody2D rb2d;
    public float speed;
    public float maxDistance, minDistance;
    [SerializeField] bool catchPlayer = false;
    float direction;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        catchPlayer = false;
        var health = collision.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            health.LoseHealth(100);
        }
    }

    void FixedUpdate()
    {
        if (!catchPlayer)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            if (transform.position.x > maxDistance)
            {
                speed = -5;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
            if (transform.position.x < minDistance)
            {
                speed = 5;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
        else
        {
            speed *= direction;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            catchPlayer = true;
            direction = Mathf.Sign(collision.transform.position.x - transform.position.x);
        }

    }


}

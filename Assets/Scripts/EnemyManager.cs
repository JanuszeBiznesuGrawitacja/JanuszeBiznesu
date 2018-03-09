using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    Rigidbody2D rb2d;
    public float speed;
    public float maxDistance, minDistance;
    bool catchPlayer = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            Debug.Log("Enter");
            health.LoseHealth(100);
        }
    }

    void FixedUpdate()
    {
        if(!catchPlayer)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            if(transform.position.x > maxDistance)
            {
                speed = -5;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
            if(transform.position.x<minDistance)
            {
                speed = 5;
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            catchPlayer = true;
            float direction = Mathf.Sign(collision.transform.position.x- transform.position.x);
            speed *= direction;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            catchPlayer = false;
        }
    }

}

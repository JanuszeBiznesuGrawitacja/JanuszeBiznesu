using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour {

    Rigidbody2D rb2d;
    Vector3 startPosition;
    public int speed;
    [SerializeField] bool seePlayer = false;
    public float relativeVelocityToKill;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }

    void Start()
    {
        startPosition = transform.position;
    }


    void FixedUpdate()
    {
        if(seePlayer) rb2d.velocity = Vector2.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Debug.Log("Found Player");
            seePlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("I can't see player");
            seePlayer = false;
        }
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

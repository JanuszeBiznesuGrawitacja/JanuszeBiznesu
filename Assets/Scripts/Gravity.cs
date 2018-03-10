using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour {

    [Range(0,10)]
    public float gravityScalemin;
    [Range(0, 10)]
    public float gravityScalemax;
    bool gravity=false;
    Rigidbody2D rb2d;
    public GameObject booble;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) gravity = !gravity;
        ChangeGravity(gravity);

    }

    void ChangeGravity(bool gravity)
    {
        if(gameObject.GetComponent<PlatformerCharacter2D>().enabled == true)
        {
            rb2d.gravityScale = gravity ? gravityScalemax : gravityScalemin;
            booble.SetActive(gravity);
        }

    }

}

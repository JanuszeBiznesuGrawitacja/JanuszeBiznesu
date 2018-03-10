using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour {

	[Range(0, 10)]
	public float gravityScalemin;

	[Range(0, 10)]
	public float gravityScalemax;

	private bool gravity = false;
	private Rigidbody2D rb2d;
	public GameObject booble;

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			gravity = !gravity;
			ChangeGravity(gravity);
		}
	}

	private void ChangeGravity(bool gravity) {
		if (gameObject.GetComponent<PlatformerCharacter2D>().enabled == true)
		{
			//SoundsManager.instance.PlayActivateGravitySound(gravity);
			rb2d.gravityScale = gravity ? gravityScalemax : gravityScalemin;
			booble.SetActive(gravity);
		}
	}

    public void CheckGravity()
    {
        if (gravity) ChangeGravity(false);
    }
}
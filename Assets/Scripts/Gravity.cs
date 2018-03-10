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

	private bool gravityState = false;
	private Rigidbody2D rb2d;
	public GameObject booble;

	private void Start() {
		rb2d = GetComponent<Rigidbody2D>();
		ChangeGravity(false);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Q))
		{
			ChangeGravity(!gravityState);
		}
	}

	private void ChangeGravity(bool gravity) {
		SoundsManager.instance.PlayActivateGravitySound(gravity);
		gravityState = gravity;
		rb2d.gravityScale = gravity ? gravityScalemax : gravityScalemin;
		booble.SetActive(gravity);
	}

	public void CheckGravity() {
		if (gravityState)
			ChangeGravity(false);
	}
}
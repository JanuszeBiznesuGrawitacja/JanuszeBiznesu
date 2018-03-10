using System;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerController : MonoBehaviour {
	private Platformer2DUserControl userControl;
	private PlatformerCharacter2D platformerCharacter2D;
	private Gravity gravity;
	private Animator animator;
	public bool enteredExit;
	public AudioClip[] jumpSounds;
	private bool isActive;

	private void Awake() {
		userControl = GetComponent<Platformer2DUserControl>();
		platformerCharacter2D = GetComponent<PlatformerCharacter2D>();
		gravity = GetComponent<Gravity>();
		platformerCharacter2D.OnCharacterJump += Jump;
		animator = GetComponent<Animator>();
		SetAsActivePlayer(false);
	}

	public void SetAsActivePlayer(bool state) {
		if (!state)
		{
			animator.SetTrigger("Idle");
			animator.SetBool("Ground", true);
			animator.SetFloat("Speed", 0);

			if (platformerCharacter2D.m_Rigidbody2D != null)
				platformerCharacter2D.m_Rigidbody2D.velocity = new Vector2(0, 0);
		}
		gravity.enabled = state;
		userControl.enabled = state;
		platformerCharacter2D.enabled = state;
		isActive = state;
	}

	public void Jump() {
		SoundsManager.instance.PlaySound(jumpSounds);
	}
}
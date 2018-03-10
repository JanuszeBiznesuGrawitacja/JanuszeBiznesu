using System;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerController : MonoBehaviour {
	private Platformer2DUserControl userControl;
	private PlatformerCharacter2D platformerCharacter2D;
	private Animator animator;
	public bool enteredExit;
	public AudioClip[] jumpSounds;
	private bool isActive;

	private void Awake() {
		userControl = GetComponent<Platformer2DUserControl>();
		platformerCharacter2D = GetComponent<PlatformerCharacter2D>();
		platformerCharacter2D.OnCharacterJump += Jump;
		animator = GetComponent<Animator>();
		SetAsActivePlayer(false);
	}

	public void SetAsActivePlayer(bool state) {
		userControl.enabled = state;
		platformerCharacter2D.enabled = state;
		animator.enabled = state;
		isActive = state;
	}

	public void Jump() {
		SoundsManager.instance.PlaySound(jumpSounds);
	}
}
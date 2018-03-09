using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerController : MonoBehaviour {
	private Platformer2DUserControl userControl;
	private PlatformerCharacter2D platformerCharacter2D;
	private Animator animator;

	private void Awake() {
		userControl = GetComponent<Platformer2DUserControl>();
		platformerCharacter2D = GetComponent<PlatformerCharacter2D>();
		animator = GetComponent<Animator>();
		SetAsActivePlayer(false);
	}

	public void SetAsActivePlayer(bool state) {
		userControl.enabled = state;
		platformerCharacter2D.enabled = state;
		animator.enabled = state;
	}
}
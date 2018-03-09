using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelPortal : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision) {
		var playerController = collision.GetComponent<PlayerController>();
		if (playerController)
		{
			playerController.enteredExit = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision) {
		var playerController = collision.GetComponent<PlayerController>();
		if (playerController)
		{
			playerController.enteredExit = false;
		}
	}
}
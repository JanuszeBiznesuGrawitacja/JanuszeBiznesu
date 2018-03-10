using UnityEngine;

public class Crate : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player")
		{
			SoundsManager.instance.PlayKickChestSound();
		}
	}
}
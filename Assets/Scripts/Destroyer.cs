using UnityEngine;

public class Destroyer : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision) {
		var health = collision.GetComponentInParent<Health>();
		if (health)
		{ health.Die(); }
		else
		{
			Destroy(collision.gameObject);
		}
	}
}
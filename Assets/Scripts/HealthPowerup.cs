using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HealthPowerup : MonoBehaviour {
	public float healthRefillAmount;

	private void OnTriggerEnter2D(Collider2D collision) {
		var health = collision.GetComponent<Health>();
		if (health != null)
		{
			health.AddHealth(healthRefillAmount);
			Destroy(gameObject);
		}
	}
}
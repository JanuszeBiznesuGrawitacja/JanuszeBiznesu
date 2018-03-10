using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class HealthPowerup : MonoBehaviour {
	public float healthRefillAmount = 10;

	private void OnTriggerEnter2D(Collider2D collision) {
		var health = collision.GetComponentInParent<Health>();
		if (health != null)
		{
			health.AddHealth(healthRefillAmount);
			SoundsManager.instance.PlayPickPowerUpSound();
			Destroy(gameObject);
		}
	}
}
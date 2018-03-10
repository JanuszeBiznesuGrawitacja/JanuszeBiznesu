using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {
	private Rigidbody2D rb2d;
	private float damage = 5f;
	private Vector2 yRange = new Vector2(40, 110);
	private Vector2 xRange = new Vector2(150, 250);

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Start() {
		var force = new Vector2(Random.Range(yRange.x, yRange.y) * RandomSign(), Random.Range(xRange.x, xRange.y));
		rb2d.AddForce(force);
	}

	private float RandomSign() {
		return Random.value < .5 ? 1 : -1;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		var health = collision.gameObject.GetComponentInParent<Health>();
		if (health)
		{
			health.LoseHealth(damage, true);
			Destroy(gameObject);
		}
		else if (collision.gameObject.tag == "Floor")
		{
			Destroy(gameObject);
		}
	}
}
using UnityEngine;

public class EnemyManager : MonoBehaviour {
	private Rigidbody2D rb2d;
	public float speed;
	public float walkingRange;
	public float sightRange;
	private float direction = 1;
	private Vector3 startPosition;
	private Transform target;

	public float Direction {
		get
		{
			return direction;
		}

		set
		{
			if (value != direction)
			{
				direction = value;
				transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
			}
		}
	}

	private void Awake() {
		rb2d = GetComponent<Rigidbody2D>();
		startPosition = transform.position;
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		var health = collision.collider.GetComponentInParent<Health>();
		if (health != null)
		{
			health.LoseHealth(100);
		}
		else if (collision.gameObject.CompareTag("Obstacle"))
		{
			Direction *= -1;
		}
	}

	private void OnCollisionStay2D(Collision2D collision) {
		var health = collision.collider.GetComponentInParent<Health>();
		if (health != null)
		{
			health.LoseHealth(100);
		}
	}

	private void Update() {
		if (!target)
		{
			if (transform.position.x > startPosition.x + walkingRange)
			{
				Direction = -1;
			}
			else if (transform.position.x < startPosition.x - walkingRange)
			{
				Direction = 1;
			}
		}
		else
		{
			var distance = target.position.x - transform.position.x;
			Direction = Mathf.Sign(distance);
			if (Mathf.Abs(distance) > sightRange)
			{
				target = null;
			}
		}
		rb2d.velocity = new Vector2(speed * Direction, rb2d.velocity.y);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.tag == "Player")
		{
			target = collision.transform;
		}
	}
}
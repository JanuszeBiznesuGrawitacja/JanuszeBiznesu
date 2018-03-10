using UnityEngine;

public class GarbageStack : MonoBehaviour {
	public GameObject[] projectiles;
	private float spawnEverySeconds = 2f;
	private float timer;

	private void Update() {
		timer += Time.deltaTime;
		if (timer >= spawnEverySeconds)
		{
			timer = 0;
			ShootProjectile();
		}
	}

	private void ShootProjectile() {
		var projectilePrefab = projectiles[Random.Range(0, projectiles.Length)];
		var rotation = Random.rotation.z;
		var projectileGO = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, rotation));
		projectileGO.SetActive(true);
	}
}
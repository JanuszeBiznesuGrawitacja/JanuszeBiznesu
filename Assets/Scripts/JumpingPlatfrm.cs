using UnityEngine;

public class JumpingPlatfrm : MonoBehaviour {
	[SerializeField] private float relativeVelocityToBreak = 1f;

	[SerializeField] private GameObject ourPipe;

	public GameObject pieceBoard;
	public Transform spawnPoint, spawnPoint1;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (collision.relativeVelocity.magnitude >= relativeVelocityToBreak)
		{
			Instantiate(pieceBoard, spawnPoint.position, Quaternion.identity);
			Instantiate(pieceBoard, spawnPoint1.position, Quaternion.identity);
			SoundsManager.instance.PlayBrokenPlankSound();
			Destroy(ourPipe);
		}
	}
}
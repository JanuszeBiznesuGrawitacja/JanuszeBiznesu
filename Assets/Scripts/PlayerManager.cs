using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerManager : MonoBehaviour {
	public GameObject player1, player2;
	private bool changePlayer = false;
	private GameObject _currentPlayer;
	private Camera2DFollow _camera2DFollow;

	private void Awake() {
		_currentPlayer = player1;
		player1.GetComponent<Platformer2DUserControl>().enabled = true;
		player2.GetComponent<Platformer2DUserControl>().enabled = false;
		player1.GetComponent<PlatformerCharacter2D>().enabled = true;
		player2.GetComponent<PlatformerCharacter2D>().enabled = false;
		player1.GetComponent<Animator>().enabled = true;
		player2.GetComponent<Animator>().enabled = false;
		_camera2DFollow = FindObjectOfType<Camera2DFollow>();
		_camera2DFollow.target = _currentPlayer.transform;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab)) changePlayer = !changePlayer;
		ChangePlayer(changePlayer);
	}

	private void ChangePlayer(bool change) {
		if (change)
		{
			player1.GetComponent<Platformer2DUserControl>().enabled = false;
			player2.GetComponent<Platformer2DUserControl>().enabled = true;
			player1.GetComponent<PlatformerCharacter2D>().enabled = false;
			player2.GetComponent<PlatformerCharacter2D>().enabled = true;
			player1.GetComponent<Animator>().enabled = false;
			player2.GetComponent<Animator>().enabled = true;
			_currentPlayer = player2;
		}
		else
		{
			player1.GetComponent<Platformer2DUserControl>().enabled = true;
			player2.GetComponent<Platformer2DUserControl>().enabled = false;
			player1.GetComponent<PlatformerCharacter2D>().enabled = true;
			player2.GetComponent<PlatformerCharacter2D>().enabled = false;
			player1.GetComponent<Animator>().enabled = true;
			player2.GetComponent<Animator>().enabled = false;
			_currentPlayer = player1;
		}
		_camera2DFollow.target = _currentPlayer.transform;
	}
}
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayersManager : MonoBehaviour {
	private PlayerController[] players;
	private int activePlayerIndex;

	private Camera2DFollow _camera2DFollow;

	private void Awake() {
		_camera2DFollow = FindObjectOfType<Camera2DFollow>();
		players = GetComponentsInChildren<PlayerController>();
	}

	private void Start() {
		players[0].SetAsActivePlayer(true);
		_camera2DFollow.target = GetCurrentPlayer().transform;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			ChangePlayer();
		}
	}

	private void ChangePlayer() {
		GetCurrentPlayer().SetAsActivePlayer(false);
		activePlayerIndex = (activePlayerIndex + 1) % players.Length;
		GetCurrentPlayer().SetAsActivePlayer(true);
		_camera2DFollow.target = GetCurrentPlayer().transform;
	}

	private PlayerController GetCurrentPlayer() {
		return players[activePlayerIndex];
	}
}
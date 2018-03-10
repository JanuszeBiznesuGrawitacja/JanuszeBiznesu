using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using DG.Tweening;

public class PlayersManager : MonoBehaviour {
	public string sceneToLoad;

	private SpriteRenderer[] sr;

	private PlayerController[] players;
	private int activePlayerIndex;

	private Camera2DFollow _camera2DFollow;

	private void Awake() {
		_camera2DFollow = FindObjectOfType<Camera2DFollow>();
		players = GetComponentsInChildren<PlayerController>();
		sr = GetComponentsInChildren<SpriteRenderer>();
	}

	private void Start() {
		SoundsManager.instance.LecimyNaMarsa();
		players[0].SetAsActivePlayer(true);
		_camera2DFollow.target = GetCurrentPlayer().transform;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			ChangePlayer();
		}
		else if (Input.GetKeyDown(KeyCode.R))
		{
			SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		}
		if (AllPlayersStaysAtExitPortal())
		{
			LoadNextLevel();
		}
	}

	private void ChangePlayer() {
		GetCurrentPlayer().SetAsActivePlayer(false);
		var player = GetCurrentPlayer();
		player.GetComponent<Gravity>().CheckGravity();
		activePlayerIndex = (activePlayerIndex + 1) % players.Length;
		GetCurrentPlayer().SetAsActivePlayer(true);
		DOTween.Sequence().Append(sr[activePlayerIndex].DOColor(Color.clear, 0.2f))
			.Append(sr[activePlayerIndex].DOColor(Color.white, 0.2f))
			.Append(sr[activePlayerIndex].DOColor(Color.clear, 0.2f))
			.Append(sr[activePlayerIndex].DOColor(Color.white, 0.2f));
		_camera2DFollow.target = GetCurrentPlayer().transform;
	}

	private PlayerController GetCurrentPlayer() {
		return players[activePlayerIndex];
	}

	private bool AllPlayersStaysAtExitPortal() {
		for (int i = 0; i < players.Length; i++)
		{
			if (!players[i].enteredExit)
				return false;
		}

		return true;
	}

	private void LoadNextLevel() {
		SceneManager.LoadSceneAsync(sceneToLoad);
	}
}
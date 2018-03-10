using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using DG.Tweening;

public class PlayersManager : MonoBehaviour {
	public string sceneToLoad;

    SpriteRenderer[] sr;

	private PlayerController[] players;
	private int activePlayerIndex;

	private Camera2DFollow _camera2DFollow;

	private void Awake() {
		_camera2DFollow = FindObjectOfType<Camera2DFollow>();
		players = GetComponentsInChildren<PlayerController>();
        sr = GetComponentsInChildren<SpriteRenderer>();
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
		if (AllPlayersStaysAtExitPortal())
		{
			LoadNextLevel();
		}
	}

	private void ChangePlayer() {
		GetCurrentPlayer().SetAsActivePlayer(false);
		activePlayerIndex = (activePlayerIndex + 1) % players.Length;
		GetCurrentPlayer().SetAsActivePlayer(true);
        DOTween.Sequence().Append(sr[activePlayerIndex].DOColor(Color.clear, 0.5f))
            .Append(sr[activePlayerIndex].DOColor(Color.white, 0.5f))
            .Append(sr[activePlayerIndex].DOColor(Color.clear, 0.5f))
            .Append(sr[activePlayerIndex].DOColor(Color.white, 0.5f));
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
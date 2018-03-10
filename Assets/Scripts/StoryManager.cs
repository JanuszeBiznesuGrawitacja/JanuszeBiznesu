using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour {

	// Use this for initialization
	private void Start() {
	}

	// Update is called once per frame
	private void Update() {
	}

	public void Begin() {
		SoundsManager.instance.SetMainMusicTrack();
		SceneManager.LoadSceneAsync("LEVEL");
	}
}
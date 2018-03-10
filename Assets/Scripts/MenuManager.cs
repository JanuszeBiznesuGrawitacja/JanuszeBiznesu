using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	private void Start() {
		SoundsManager.instance.SetIntroMusicTrack();
	}

	public void Play() {
		SceneManager.LoadSceneAsync("Story");
	}

	public void Quit() {
		Application.Quit();
	}
}
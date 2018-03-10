using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void Play() {
		SceneManager.LoadSceneAsync("Story");
	}

	public void Quit() {
		Application.Quit();
	}
}
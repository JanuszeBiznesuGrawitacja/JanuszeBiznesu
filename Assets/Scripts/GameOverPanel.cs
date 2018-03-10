using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverPanel : MonoBehaviour {
	public static GameOverPanel instance;
	private CanvasGroup canvasGroup;

	private void Awake() {
		instance = this;
		canvasGroup = GetComponent<CanvasGroup>();
		gameObject.SetActive(false);
	}

	public void ShowGameOverScreen() {
		canvasGroup.alpha = 0;
		gameObject.SetActive(true);
		canvasGroup.DOFade(1, 0.5f);
	}

	public void RestartLevel() {
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
	}

	public void MainMenu() {
		SceneManager.LoadSceneAsync("Menu");
	}
}
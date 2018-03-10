using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour {
	[SerializeField] private GameObject[] Text;

	// Use this for initialization
	private void Start() {
		SoundsManager.instance.PlayLectorIntro();
		StartCoroutine(textManager());
	}

	// Update is called once per frame
	private void Update() {
	}

	public void Begin() {
		SoundsManager.instance.SetMainMusicTrack();
		SceneManager.LoadSceneAsync("LEVEL");
	}

	private IEnumerator textManager() {
		yield return new WaitForSeconds(3.5f);
		Text[0].SetActive(true);
		yield return new WaitForSeconds(12f);
		Text[0].SetActive(false);
		Text[1].SetActive(true);
		yield return new WaitForSeconds(22f);
		Text[1].SetActive(false);
		Text[2].SetActive(true);
		yield return new WaitForSeconds(16.5f);
		Text[2].SetActive(false);
		Text[3].SetActive(true);
		yield return new WaitForSeconds(5f);
		Text[4].SetActive(true);
		yield return 0;
	}
}
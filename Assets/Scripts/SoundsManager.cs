using UnityEngine;
using DG.Tweening;

public class SoundsManager : MonoBehaviour {
	public static SoundsManager instance;

	private AudioSource audioSource;
	public AudioSource[] musicSources;
	public AudioClip pickPowerUp;

	//Music Tracks
	public AudioClip intro;

	public AudioClip main;

	private void Awake() {
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
		audioSource = GetComponent<AudioSource>();
		SetIntroMusicTrack();
		DontDestroyOnLoad(gameObject);
	}

	public void PlayPickPowerUpSound() {
		PlaySound(pickPowerUp);
	}

	public void Stop() {
		audioSource.Stop();
		audioSource.clip = null;
	}

	private void PlaySound(AudioClip[] audioClips) {
		PlaySound(audioClips[Random.Range(0, audioClips.Length)]);
	}

	private void PlaySound(AudioClip audioClip) {
		audioSource.PlayOneShot(audioClip);
	}

	public void SetIntroMusicTrack() {
		SwitchMusicTrack(intro);
	}

	public void SetMainMusicTrack() {
		SwitchMusicTrack(main);
	}

	private int currentPlayingMusicSource;
	private AudioClip currentClip;

	private void SwitchMusicTrack(AudioClip track) {
		if (track != currentClip)
		{
			currentClip = track;
			int next = (currentPlayingMusicSource + 1) % musicSources.Length;
			musicSources[currentPlayingMusicSource].DOFade(0, 0.5f);
			musicSources[next].clip = track;
			musicSources[next].Play();
			musicSources[next].DOFade(1, 0.5f);
			currentPlayingMusicSource = next;
		}
	}

	public void FadeOutMusic(float time) {
		musicSources[currentPlayingMusicSource].DOFade(0, time);
		currentClip = null;
	}
}
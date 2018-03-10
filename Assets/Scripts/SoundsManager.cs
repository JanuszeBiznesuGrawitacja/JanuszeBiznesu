using UnityEngine;
using DG.Tweening;

public class SoundsManager : MonoBehaviour {
	public static SoundsManager instance;

	private AudioSource audioSource;
	public AudioSource[] musicSources;
	public AudioClip pickPowerUp;
	public AudioClip clickSound;
	public AudioClip[] activateGravity;
	public AudioClip[] takeDamageSounds;
	public AudioClip[] brokenPlank;
	public AudioClip[] kickChestSounds;
	public AudioClip[] dieSounds;
	public AudioClip lecimyNaMarsa;
	public AudioClip passatemNaZiemie;

	//Music Tracks
	public AudioClip intro;

	public AudioClip winSound;
	public AudioClip lector;
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

	public void PlayClickSound() {
		PlaySound(clickSound);
	}

	public void PlayPickPowerUpSound() {
		PlaySound(pickPowerUp);
	}

	public void PlayActivateGravitySound(bool state) {
		audioSource.Stop();
		if (state)
		{
			audioSource.clip = activateGravity[Random.Range(0, activateGravity.Length)];
			audioSource.Play();
		}
	}

	public void PlayTakeDamageSound() {
		PlaySound(takeDamageSounds);
	}

	public void PlayBrokenPlankSound() {
		PlaySound(brokenPlank);
	}

	public void PlayKickChestSound() {
		PlaySound(kickChestSounds);
	}

	public void PlayDieSound() {
		PlaySound(dieSounds);
	}

	public void PlayWinSound() {
		SwitchMusicTrack(winSound);
	}

	public void LecimyNaMarsa() {
		PlaySound(lecimyNaMarsa);
	}

	public void PassatemNaZiemie() {
		PlaySound(passatemNaZiemie);
	}

	public void Stop() {
		audioSource.Stop();
		audioSource.clip = null;
	}

	public void PlaySound(AudioClip[] audioClips) {
		PlaySound(audioClips[Random.Range(0, audioClips.Length)]);
	}

	public void PlaySound(AudioClip audioClip, bool isPrioritySound = true) {
		if ((!locked || isPrioritySound))
		{
			locked = true;
			audioSource.PlayOneShot(audioClip);
			Invoke("Unlock", 0.075f);
		}
	}

	private void Unlock() {
		locked = false;
	}

	private bool locked;

	public void SetIntroMusicTrack() {
		SwitchMusicTrack(intro);
	}

	public void PlayLectorIntro() {
		SwitchMusicTrack(lector);
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
			musicSources[next].loop = track != lector && track != winSound;
			var volume = track == lector ? 1 : 0.35f;
			musicSources[next].Play();
			musicSources[next].DOFade(volume, 0.5f);
			currentPlayingMusicSource = next;
		}
	}

	public void FadeOutMusic(float time) {
		musicSources[currentPlayingMusicSource].DOFade(0, time);
		currentClip = null;
	}

	public void TurnTheMusicUp() {
		musicSources[currentPlayingMusicSource].DOFade(1, 1f);
	}
}
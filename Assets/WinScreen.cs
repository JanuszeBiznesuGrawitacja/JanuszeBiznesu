using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour {

	// Use this for initialization
	private void Awake() {
		SoundsManager.instance.PlayWinSound();
		SoundsManager.instance.PassatemNaZiemie();
	}

	// Update is called once per frame
	private void Update() {
	}
}
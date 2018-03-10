using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {

    [SerializeField] GameObject paserati;
    [SerializeField] GameObject texsts;
    [SerializeField] Text name;
    [SerializeField] Text role;
    [SerializeField] GameObject button2;
    [SerializeField] Animator backgroundAnimator;
    [SerializeField] GameObject LogoGameJam;
    [SerializeField] GameObject LogoAutistic;

	// Use this for initialization
	private void Start() {
        StartCoroutine(sounding());
        StartCoroutine(names());
	}

	// Update is called once per frame
	private void Update() {


    }

    IEnumerator sounding()
    {
        SoundsManager.instance.PlayWinSound();
        yield return new WaitForSeconds(7f);
        SoundsManager.instance.PassatemNaZiemie();
        yield return new WaitForSeconds(10f);
        SoundsManager.instance.SetMainMusicTrack();

    }

    IEnumerator names()
    {
        yield return new WaitForSeconds(17f);
        paserati.SetActive(false);
        SoundsManager.instance.TurnTheMusicUp();
        yield return new WaitForSeconds(5f);
        texsts.SetActive(true);
        button2.SetActive(true);
        backgroundAnimator.enabled = true;
        yield return new WaitForSeconds(6.7f);
        name.text = "Mateusz Olszewski";
        role.text = "Senior";
        yield return new WaitForSeconds(6.7f);
        name.text = "Sebastian Januszewski";
        role.text = "Pixel king";
        yield return new WaitForSeconds(6.7f);
        name.text = "Bartosz Bąk";
        role.text = "Bóg programistów";
        yield return new WaitForSeconds(6.7f);
        name.text = "Tomasz Chwietczuk";
        role.text = "Patryk";
        yield return new WaitForSeconds(6.7f);
        name.text = "Zans Himmer";
        role.text = "Marceli Jurgielewicz";
        yield return new WaitForSeconds(6.7f);
        name.text = "Piotr Mrzygłowski";
        role.text = "Andrzej";
        yield return new WaitForSeconds(6.7f);
        name.text = "";
        role.text = "";
        LogoGameJam.SetActive(true);
        yield return new WaitForSeconds(6.5f);
        LogoGameJam.SetActive(false);
        LogoAutistic.SetActive(true);
        yield return new WaitForSeconds(6.7f);
        texsts.SetActive(false);

    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
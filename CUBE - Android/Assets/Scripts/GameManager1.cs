using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
	public AudioSource gameSong;
	public AudioSource metallicHit;
	public AudioSource DeadlyCubeHit;

	private void Start() {
		ingameOptions.SetActive(false);
		gameSong.volume = PlayerPrefs.GetFloat("SongVolume");
		metallicHit.volume = PlayerPrefs.GetFloat("SoundVolume");
		DeadlyCubeHit.volume = PlayerPrefs.GetFloat("SoundVolume");
	}

	public bool restarting = false;
	public void RestartGame()
	{
		restarting = true;
	}
	public bool startedFromQuickStartGame = false;
	public void quickRestartGame() {
		startedFromQuickStartGame = true;
		SceneManager.LoadScene("GameOverScene");
	}

	public bool pause = false;
	public GameObject pauseButton;
	public GameObject continueButton;
	public GameObject ingameOptions;
	public Score score;
	public void pauseGame() {
			ingameOptions.SetActive(true);
			pauseButton.SetActive(false);
			continueButton.SetActive(true);
			Time.timeScale = 0f;
			gameSong.Pause();
			pause = true;
	}

	public void resumeGame() {
		ingameOptions.SetActive(false);
		pauseButton.SetActive(true);
		continueButton.SetActive(false);
		Time.timeScale = 1f;
		gameSong.Play();
		pause = false;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (pause) {
				resumeGame();
			} else {
				pauseGame();
			}
		}	
	}

	public float timer;
	public bool stopCounting = false;
	public bool GameOver;
	public GameObject backgroundGameAudio;
	public inGameOptions inGameOptions;
	public bool animHasAlreadyStarted;
	public Animator screenFade;
	private void FixedUpdate()
	{
		if (restarting == true && !stopCounting) //Game Over
		{
			GameOver = true;
			timer += Time.deltaTime;

			if (AudioListener.volume > 0) {
				gameSong.volume -= 0.004f;
			}
			if (!animHasAlreadyStarted) {
				screenFade.Play("ScreenFade", 0, 0.0f);
				animHasAlreadyStarted = true;
			}

			if (timer > 4)
			{
				stopCounting = true;
				restarting = false;
				GameOver = false;
				SceneManager.LoadScene("GameOverScene");
			}
			
		}
	}
}

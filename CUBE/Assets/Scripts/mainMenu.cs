using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour {

	public TextMeshProUGUI previousScore;
	public TextMeshProUGUI highScore;

	public Slider horizontalMoveValue;


	void Start() {
		optionsMenu.SetActive(false);
		previousScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();
		highScore.text = PlayerPrefs.GetInt("HighScore").ToString();

		SongSlider.value = PlayerPrefs.GetFloat("SongVolume");
		SoundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
		horizontalMoveValue.value = PlayerPrefs.GetInt("horizontalControlForce");
	}

	public void StartGame() {
		SceneManager.LoadScene("GameplayScene");
	}
	public GameObject optionsMenu;
	public void Settings() {
		optionsMenu.SetActive(true);
	}

	public void back() {
		optionsMenu.SetActive(false);
	}

	public void ResetHighScore() {
		PlayerPrefs.SetInt("HighScore", 0);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void resetHorizontalMoveValue() {
		horizontalMoveValue.value = 250;
	}

	public Slider SongSlider;
	
	public void MusicSlider() {
		PlayerPrefs.SetFloat("SongVolume", SongSlider.value);
	}

	public Slider SoundSlider;
	public void soundSlider() {
		PlayerPrefs.SetFloat("SoundVolume", SoundSlider.value);
	}

	public AudioSource mainMenuSong;
	public void FixedUpdate() {
		PlayerPrefs.SetInt("horizontalControlForce", (int)horizontalMoveValue.value);
		mainMenuSong.volume = PlayerPrefs.GetFloat("SongVolume");
	}

	public void Exit()
	{
		Application.Quit();
	}
}
	

	

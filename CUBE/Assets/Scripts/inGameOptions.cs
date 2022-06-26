using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class inGameOptions : MonoBehaviour
{
    public Slider SongSlider;
    public Slider SoundSlider;
    public Slider horizontalMoveValue;

    public AudioSource gameMusic;
    public AudioSource metallicHit;
    public AudioSource gameOverObjectHitSound;
    void Start()
    {
        SongSlider.value = PlayerPrefs.GetFloat("SongVolume");
        SoundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        horizontalMoveValue.value = PlayerPrefs.GetInt("horizontalControlForce");
    }

    public GameManager1 gameManager;
    public void pause() {
        gameManager.pauseGame();
	}

    public void resume() {
        gameManager.resumeGame();
    }

    public void restartGame() {
        gameManager.quickRestartGame();
    }

    public void resetHorizontalForce() {
        horizontalMoveValue.value = 225;
    }

    public void Update() { //fixedUpdate doesn't work when "time.timeScale" is set to 0.
        PlayerPrefs.SetFloat("SongVolume", SongSlider.value);
        PlayerPrefs.SetFloat("SoundVolume", SoundSlider.value);

        gameMusic.volume = PlayerPrefs.GetFloat("SongVolume");
        metallicHit.volume = PlayerPrefs.GetFloat("SoundVolume");
        gameOverObjectHitSound.volume = PlayerPrefs.GetFloat("SoundVolume");

        PlayerPrefs.SetInt("horizontalControlForce", (int)horizontalMoveValue.value);
    }
}

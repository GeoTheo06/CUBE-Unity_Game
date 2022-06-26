using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
	public void retryButton()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("GameplayScene");
	}

	public void mainMenuButton()
	{
		SceneManager.LoadScene("MainMenuScene");
	}

	public void quitButton()
	{
		Application.Quit();
	}
}

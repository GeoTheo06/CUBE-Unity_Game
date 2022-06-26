using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI currentScore;
    public TextMeshProUGUI highScore;
	public GameObject highScoreInfo;

	private void Start()
	{
		currentScore.text = PlayerPrefs.GetInt("CurrentScore").ToString();

		if (PlayerPrefs.GetInt("CurrentScore") > PlayerPrefs.GetInt("HighScore")) //if the player sets a new high score, the previous high score will be saved in a var so I can use it as well.
		{
			PlayerPrefs.SetInt("PreviousHighScore", PlayerPrefs.GetInt("HighScore"));
			PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("CurrentScore"));
			highScoreInfo.SetActive(true); //congratulate the player if their current score is bigger than the overall high score.
			highScore.text = PlayerPrefs.GetInt("PreviousHighScore").ToString(); //show the previous high score so the current score and the high score aren't the same.
		} else
		{
			highScoreInfo.SetActive(false);
			highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
		}		
	}
}

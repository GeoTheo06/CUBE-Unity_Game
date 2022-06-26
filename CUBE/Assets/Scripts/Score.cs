using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
	public Transform player;
	public TextMeshProUGUI scoreInText;

	public int finalScoreNumber;

	public bool animHasAlreadyStarted = false;
	public GameManager1 gameManager;
	[SerializeField] private Animator pauseButtonFading;
	[SerializeField] private Animator scoreFading;
	public GameObject pauseButton;
	private void FixedUpdate()
	{

			//Score numbers increase by distance
			finalScoreNumber = (int)player.position.x - 20; //I need to substract 20 because the starting player position is 20.
			finalScoreNumber = ((int)(finalScoreNumber / 10)) * 10;

			PlayerPrefs.SetInt("CurrentScore", finalScoreNumber);

			scoreInText.text = finalScoreNumber.ToString();

			if (gameManager.GameOver == true && !animHasAlreadyStarted) {
				scoreFading.Play("ScoreFade", 0, 0.0f);
				pauseButtonFading.Play("pauseButtonFade", 0, 0.0f);
				animHasAlreadyStarted = true;
			}
	}
}

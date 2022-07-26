using UnityEngine;

public class GameOver : MonoBehaviour
{
	public GameObject VeryGoodPie;
	public GameObject GoodPie;
	void OnEnable()
	{
		int currentScore = PlayerPrefs.GetInt("Score");
		int highScore = PlayerPrefs.GetInt("HighScore");

		if (currentScore > highScore)
		{
			PlayerPrefs.SetInt("HighScore", currentScore);
			highScore = currentScore;
			PlayerPrefs.Save();

			VeryGoodPie.SetActive(true);
			GoodPie.SetActive(false);
		}
		else
		{
			GoodPie.SetActive(true);
			VeryGoodPie.SetActive(false);
		}

		GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>().text = $"Your Score: {currentScore.ToString()} \nHigh Score: {highScore.ToString()}";
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour
{
	public static UIPanel Instance;

	public TMPro.TextMeshProUGUI ScoreText;
	public TMPro.TextMeshProUGUI Timer;
	public float count = 1;
	public bool isCounting;

	private int _score;

	private void Awake()
	{
		Instance = this;
		ScoreText.text = "0";
		Timer.text = "0";
		count = 60;
		isCounting = true;
	}
	void Start()
	{
		//CountTime();
	}
	public void AddScore(int score)
	{
		_score += score;
		ScoreText.text = _score.ToString();
	}

	public void CountTime()
	{
		if (GameManager.Instance.gameRunning) StartCoroutine(Counter());
	}
	private IEnumerator Counter()
	{

		while (count > 0 && isCounting)
		{
			isCounting = false;
			count -= Time.deltaTime;
			count = (int)count;
			Timer.text = count.ToString();
			yield return new WaitForSeconds(1f);
			isCounting = true;
		}
		if (count <= 0)
		{
			GameManager.Instance.GameOver(ScoreText.text);

		}
	}

	void Update()
	{
		// Flash the time remaining text
		if (isCounting && count < 10)
		{
			Timer.color = Color.red;
			WaitForSeconds wait = new WaitForSeconds(0.5f);
		}
		else
		{
			Timer.color = Color.white;
			WaitForSeconds wait = new WaitForSeconds(0.5f);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
	public static GameManager Instance;
	public bool gameRunning = false;
	public FruitController fruitController;

	private void Awake()
	{
		Instance = this;
		StartGame();
	}

	public void StartGame()
	{
		gameRunning = true;
		StartCoroutine(LoadUI());
	}

	public void GameOver()
	{
		gameRunning = false;
		fruitController.StopAllCoroutines();
		SceneManager.LoadScene("GameOver");
		Debug.Log("Game Over!!");
	}

	private IEnumerator LoadUI()
	{
		yield return SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);
		Debug.Log("UI Scene Loaded");

		AudioManager.Instance.MusicVolume = 0.5f;
		AudioManager.Instance.PlayBackground();


		Debug.Log("Audiomanager should be ready");
	}


}

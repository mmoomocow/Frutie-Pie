using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
	public static GameManager Instance;
	public bool gameRunning = false;
	public FruitController fruitController;
	public Transform BirdSpawnPoint;
	public GameObject BirdPrefab;

	private void Awake()
	{
		Instance = this;
		StartGame();
	}

	public void StartGame()
	{
		gameRunning = true;
		StartCoroutine(LoadUI());
		StartCoroutine(BirdSpawner());
	}

	public void GameOver(string scoreText)
	{
		gameRunning = false;
		fruitController.StopAllCoroutines();

		// Save score
		PlayerPrefs.SetInt("Score", int.Parse(scoreText));
		PlayerPrefs.Save();
		SceneManager.LoadScene("GameOver");
	}

	private IEnumerator LoadUI()
	{
		yield return SceneManager.LoadSceneAsync("UIScene", LoadSceneMode.Additive);

		AudioManager.Instance.MusicVolume = 0.5f;
		AudioManager.Instance.PlayBackground();
	}

	public void SpawnBird()
	{
		GameObject bird = Instantiate(BirdPrefab, BirdSpawnPoint.position, BirdSpawnPoint.rotation);
		AudioManager.Instance.PlayBird();
		Destroy(bird, 5f);
	}

	public IEnumerator BirdSpawner()
	{
		while (gameRunning)
		{
			yield return new WaitForSeconds(Random.Range(5f, 20f));
			SpawnBird();
		}
	}
}

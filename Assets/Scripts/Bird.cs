using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
	public float speed;
	public GameObject ShitPrefab;
	public Transform ShitLauncher;
	public float shitSpawnDelay = 1f;
	public float shitSpawnVariation = 1f;

	void Start()
	{
		StartCoroutine(LaunchShit());
	}

	public IEnumerator LaunchShit()
	{
		while (true)
		{
			// Randomly pick a number between 0 and 10 to decide if the shit spawns or not.
			int randomNumber = Random.Range(0, 10);
			if (randomNumber < 5)
			{
				// Spawn
				yield return new WaitForSeconds(Random.Range(shitSpawnDelay - shitSpawnVariation, shitSpawnDelay + shitSpawnVariation));
				GameObject shit = Instantiate(ShitPrefab, ShitLauncher.position, ShitLauncher.rotation);
			}
			else
			{
				// Don't spawn
				yield return new WaitForSeconds(shitSpawnDelay);
			}
		}
	}

	void Update()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}
}

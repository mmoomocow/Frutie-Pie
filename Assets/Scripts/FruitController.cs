using System.Collections;
using UnityEngine;

public class FruitController : MonoBehaviour
{
	[SerializeField] public int scoreValue = 1;
	[SerializeField] private Transform SpawnPoint;
	[SerializeField] private GameObject[] fruits;
	[SerializeField] private float maxSpeed;
	[SerializeField] private float minSpeed;
	[SerializeField] private float spawnCooldown = 2f;
	[SerializeField] private float spawnVariation = 1f;
	[SerializeField] private float lifeTime = 5f;
	private float speed;

	void Start()
	{
		// Start fruit spawning
		StartCoroutine(SpawnFruit());
	}

	private IEnumerator SpawnFruit()
	{
		yield return new WaitForSeconds(spawnCooldown);
		while (enabled)
		{
			// Randomly select a fruit from the array
			int fruitIndex = Random.Range(0, fruits.Length);

			// Create a new fruit
			GameObject fruitObj = Instantiate(fruits[fruitIndex], SpawnPoint.position, SpawnPoint.rotation);

			// Get the fruit's rigidbody
			Rigidbody2D fruitRb = fruitObj.GetComponent<Rigidbody2D>();

			// Set the fruit's speed
			speed = Random.Range(minSpeed, maxSpeed);
			fruitRb.AddForce(fruitObj.transform.right * -speed, ForceMode2D.Impulse);

			// Randomly add some rotation as a force
			float rotation = Random.Range(-maxSpeed, maxSpeed);
			fruitRb.AddTorque(rotation);

			// Randomly vary the spawn cooldown
			float trueSpawnTime = Random.Range(spawnCooldown - spawnVariation, spawnCooldown + spawnVariation);
			Debug.Log("Spawning fruit in " + trueSpawnTime + " seconds");

			// Wait for the spawn time to expire
			yield return new WaitForSeconds(trueSpawnTime);

			// Destroy the fruit after it has been alive for the specified time
			Destroy(fruitObj, lifeTime);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{
	[SerializeField] public int scoreValue = 1;
	[SerializeField] private Transform SpawnPoint;
	//[SerializeField] private GameObject[] fruits;
	[SerializeField] private float maxSpeed;
	[SerializeField] private float minSpeed;
	[SerializeField] private float spawnCooldown = 2f;
	[SerializeField] private float spawnVariation = 1f;
	[SerializeField] private float lifeTime = 5f;
	public Animator animator;
	public Animator animator2;


	public GameObject baseFruitPrefab;

	private float speed;

	private bool isThrowing = false;
	void Update()
	{
		// Start fruit spawning
		if (GameManager.Instance.gameRunning)
		{
			StartCoroutine(SpawnFruit());
			UIPanel.Instance.CountTime();
		}
	}
	private IEnumerator SpawnFruit()
	{

		if (!isThrowing)
		{
			isThrowing = true;
			// Randomly select a fruit from the array

			List<GameObject> fruitList = new List<GameObject>();


			// Play Monkey animation
			animator.SetBool("Throw", true);
			animator2.SetBool("Throw", true);

			// Create a new fruit

			yield return new WaitForSeconds(0.5f);
			GameObject fruitObj = Instantiate(baseFruitPrefab, SpawnPoint.position, SpawnPoint.rotation);
			AudioManager.Instance.PlayShootingSound();

			foreach (Transform child in fruitObj.transform)
			{
				fruitList.Add(child.gameObject);
			}
			int fruitIndex = Random.Range(0, fruitList.Count);
			fruitList[fruitIndex].SetActive(true);

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

			// Wait for the spawn time to expire
			yield return new WaitForSeconds(trueSpawnTime);
			animator.SetBool("Throw", false);
			animator2.SetBool("Throw", false);

			// Destroy the fruit after it has been alive for the specified time
			Destroy(fruitObj, lifeTime);
			isThrowing = false;

		}
	}
}

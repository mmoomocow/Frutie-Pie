using System.Collections;
using UnityEngine;

public class FruitController : MonoBehaviour
{
	[SerializeField] public int scoreValue = 1;
	[SerializeField] private Transform SpawnPoint;
	[SerializeField] private GameObject fruit;
	[SerializeField] private float maxSpeed;
	[SerializeField] private float minSpeed;
	[SerializeField] private float spawnCooldown = 2f;
	[SerializeField] private float lifeTime = 5f;
	private float speed;

	void Start()
	{
		StartCoroutine(SpawnFruit());
	}

	private IEnumerator SpawnFruit()
	{
		yield return new WaitForSeconds(spawnCooldown);
		while (enabled)
		{
			speed = Random.Range(minSpeed, maxSpeed);
			GameObject fruitObj = Instantiate(fruit, SpawnPoint.position, SpawnPoint.rotation);
			Rigidbody2D fruitRb = fruitObj.GetComponent<Rigidbody2D>();
			fruitRb.AddForce(fruitObj.transform.right * -speed, ForceMode2D.Impulse);
			yield return new WaitForSeconds(spawnCooldown);
			Destroy(fruitObj, lifeTime);
		}
	}
}

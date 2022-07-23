using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
	private BoxCollider2D bc;

	private float timeLimit = 2f;
	void Start()
	{
		bc = GetComponent<BoxCollider2D>();
	}

	// When the fruit hits the ground, the ground will destroy the fruit.
	void OnTriggerEnter2D(Collider2D other)
	{
		// Only target fruit
		if (other.gameObject.tag == "Fruit")
		{
			// Destroy the fruit
			Destroy(other.gameObject, timeLimit);

			other.gameObject.GetComponent<CircleCollider2D>().enabled = false;

		}
	}
	
}

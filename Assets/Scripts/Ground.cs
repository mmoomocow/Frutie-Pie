using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
	private BoxCollider2D bc;
	void Start()
	{
		bc = GetComponent<BoxCollider2D>();
	}

	// When the fruit hits the ground, the ground will destroy the fruit.
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Fruit")
		{
			Destroy(other.gameObject);
			Debug.Log("Fruit squashed!");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
	private Rigidbody2D rb;
	// When the fruit hits the catcher, the catcher will destroy the fruit.
	void OnTriggerEnter2D(Collider2D other)
	{
		// Only target fruit
		if (other.gameObject.tag == "Fruit")
		{
			// Destroy the fruit
			Destroy(other.gameObject);
			UIPanel.Instance.AddScore(1);
		}
	}
}

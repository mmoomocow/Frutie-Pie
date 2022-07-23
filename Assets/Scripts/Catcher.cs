using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{
	private Rigidbody2D rb;
	private BoxCollider2D bc;

	// When the fruit hits the catcher, the catcher will destroy the fruit.
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Fruit")
		{
			Destroy(other.gameObject);
			UIPanel.Instance.AddScore(1);
			
		 	
		}
	}
}

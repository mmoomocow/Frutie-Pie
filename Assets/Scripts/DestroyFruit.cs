using UnityEngine;

public class DestroyFruit : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Fruit")
		{
			// Destroy the fruit
			Destroy(other.gameObject);
		}
	}
}

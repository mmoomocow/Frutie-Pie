using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shit : MonoBehaviour
{
	public PolygonCollider2D bc;
	public float speedDevisor = 2f;
	public float debuffTime = 1f;

	private bool hitPlayer = false;


	void Start()
	{
		StartCoroutine(DestroyAfterXSeconds(10f));
	}

	public IEnumerator DestroyAfterXSeconds(float time)
	{
		yield return new WaitForSeconds(time);
		if (!hitPlayer)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			hitPlayer = true;

			float speed = other.gameObject.GetComponent<PlayerMovement>().speed;

			float originalSpeed = speed;
			speed = speed / speedDevisor;
			other.gameObject.GetComponent<PlayerMovement>().speed = speed;

			Debug.Log($"Speed changed from {originalSpeed} to {speed}");

			StartCoroutine(RestoreSpeed(other.gameObject, originalSpeed));

			bc.enabled = false;
		}
	}

	IEnumerator RestoreSpeed(GameObject obj, float originalSpeed)
	{
		Debug.Log("Debuffing");
		yield return new WaitForSeconds(debuffTime);
		Debug.Log("Restoring");
		obj.gameObject.GetComponent<PlayerMovement>().speed = 7f; // originalSpeed;
		Debug.Log("Restored");
		Destroy(gameObject);
	}
}

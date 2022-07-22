using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	BoxCollider2D bc;
	[SerializeField] public float speed = 10f;
	[SerializeField] public float jumpForce = 10f;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		float x = Input.GetAxis("Horizontal");
		Vector2 movement = new Vector2(x, 0);
		rb.velocity = movement * speed;
	}
}

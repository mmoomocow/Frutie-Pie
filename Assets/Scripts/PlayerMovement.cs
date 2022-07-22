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
		move();

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
		{
			jump();
		}


	}

	void move()
	{
		float x = Input.GetAxis("Horizontal");
		x = x * Time.deltaTime * speed;

		// flip the player 
		if (rb.velocity.x < 0) transform.localScale = new Vector3(-1, 1, 1);
		else if (rb.velocity.x > 0) transform.localScale = new Vector3(1, 1, 1);
		rb.velocity = new Vector2(x, rb.velocity.y);
	}

	void jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
	}

	bool isGrounded()
	{
		return Physics2D.Raycast(transform.position, Vector2.down, bc.bounds.extents.y + 0.1f);
	}
}
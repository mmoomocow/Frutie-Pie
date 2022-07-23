using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	BoxCollider2D bc;
	[SerializeField] public float speed = 10f;
	[SerializeField] public float jumpForce = 10f;
	[SerializeField] public float bounds = 7f;
	private bool isGrounded;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		move();

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			jump();
		}


	}

	void move()
	{
		float x = Input.GetAxisRaw("Horizontal");

		if (x < 0 && transform.position.x > -bounds)
		{
			// transform.Translate(transform.right * -speed * Time.deltaTime);
			transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
		}
		else if (x > 0 && transform.position.x < bounds)
		{
			// transform.Translate(transform.right * speed * Time.deltaTime);
			transform.position += new Vector3(x * speed * Time.deltaTime, 0, 0);
		}


		// flip the player 
		if (x < 0) transform.localScale = new Vector3(-1, 1, 1);
		else if (x > 0) transform.localScale = new Vector3(1, 1, 1);
	}

	void jump()
	{
		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		isGrounded = false;
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.CompareTag("Ground"))
		{
			isGrounded = true;
		}
	}
}
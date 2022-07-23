using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	Rigidbody2D rb;
	BoxCollider2D bc;
	[SerializeField] public Animator an;
	[SerializeField] public float speed = 10f;
	[SerializeField] public float jumpForce = 10f;
	[SerializeField] public float bounds = 7f;
	private bool isGrounded;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
		an = GetComponent<Animator>();
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
		// Get the horizontal input
		float x = Input.GetAxisRaw("Horizontal");

		// Move the player but don't allow it to go outside the bounds of the screen
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


		// flip the player to the left/right
		if (x < 0) transform.localScale = new Vector3(-1, 1, 1);
		else if (x > 0) transform.localScale = new Vector3(1, 1, 1);

		// // Animate the player
		// if (x != 0) an.SetBool("running", true);
		// else an.SetBool("running", false);
	}

	void jump()
	{
		// Add a vertical force to the player and leave the horizontal force alone
		rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		// Player jumped, so they are no longer grounded
		isGrounded = false;
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.CompareTag("Ground"))
		{
			// Player touched the ground, so they are now grounded
			isGrounded = true;
		}
	}

}
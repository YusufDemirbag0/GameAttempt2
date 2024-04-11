using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
	private Rigidbody2D body;
	private Animator animator;
	private bool Running;
	private bool Grounded;
	[SerializeField] private float movementSpeed;
	[SerializeField] private float jumpingAmount;

	void Awake()
	{
		body = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		body.velocity = new Vector2(horizontalInput * movementSpeed, body.velocity.y);

		//Flipping player left and right.
		if(horizontalInput > 0.01f)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if(horizontalInput < -0.01f)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if(Input.GetKey(KeyCode.Space) && Grounded == true)
		{
			Jump();
		}
		
		if(body.velocity.x == 0)
		{
			Running = false;
		}

		if(body.velocity.x != 0)
		{
			Running = true;
		}
		
		//Set animator parameters.
		animator.SetBool("Running", Running);
		animator.SetBool("Grounded", Grounded);
		animator.SetFloat("yVelocity", body.velocity.y);
	}

	private void Jump()
	{
		body.velocity = new Vector2(body.velocity.x, jumpingAmount);
		Grounded = false;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			Grounded = true;
		}
	}
}

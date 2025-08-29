using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[Header("Movement")]
	public float Speed;

	[Header("Jump")]
	public float JumpPower;


	private Rigidbody2D rb;
	private GatherInput gatherInput;
	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		gatherInput = GatherInput.Instance;
	}

	private void Update()
	{
		FlipPlayer();
		Debug.Log(gatherInput.TryToJump);
		if (gatherInput.TryToJump)
		{
			Jump();
		}
	}

	private void FlipPlayer()
	{
		if (gatherInput.ValueX > 0)
		{
			spriteRenderer.flipX = false;
		}
		else if (gatherInput.ValueX < 0)
		{
			spriteRenderer.flipX = true;
		}
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		rb.linearVelocity = new Vector2(gatherInput.ValueX * Speed, rb.linearVelocity.y);
	}

	private void Jump()
	{
		rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Force);
	}
}

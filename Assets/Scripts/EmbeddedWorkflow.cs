using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class EmbeddedWorkflow : MonoBehaviour
{
	private Rigidbody2D rb;
	public float Speed;
	public InputAction jumpAction;
	public InputAction moveAction;
	public bool exampleBool;
	private Vector2 direction;

	private void Start()
	{
		rb= GetComponent<Rigidbody2D>();
		jumpAction.performed += Jump;
		moveAction.canceled += StopMove;
		jumpAction.canceled += StopJump;
		moveAction.performed += Move;
		jumpAction.Enable();
		moveAction.Enable();
	}

	private void OnDisable()
	{
		jumpAction.performed -= Jump;
		moveAction.canceled -= StopMove;
		jumpAction.canceled -= StopJump;
		moveAction.performed -= Move;
		jumpAction.Disable();
	}

	private void Move(InputAction.CallbackContext value)
	{
		direction = value.ReadValue<Vector2>().normalized;
		rb.linearVelocity = direction * Speed * Time.deltaTime;
	}

	private void StopMove(InputAction.CallbackContext value)
	{
		direction = Vector3.zero;
	}

	private void StopJump(InputAction.CallbackContext value)
	{
		exampleBool = value.ReadValueAsButton();
		Debug.Log("Jump Canceled... with bool: " + exampleBool);
	}

	private void Jump(InputAction.CallbackContext value)
	{
		exampleBool = value.ReadValueAsButton();
		Debug.Log("Jump performed... with bool: " + exampleBool);
	}

	private void Update()
	{
		rb.linearVelocity = direction * Speed * Time.deltaTime;
	}
}

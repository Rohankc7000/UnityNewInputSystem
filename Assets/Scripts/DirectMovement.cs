using UnityEngine;
using UnityEngine.InputSystem;

public class DirectMovement : MonoBehaviour
{
	[SerializeField] private float speed;
	private Rigidbody2D rb;
	private float valueX;
	private float valueY;
	private Vector2 direction;
	private Vector2 gamepadDirection;
	private Keyboard myKeyboard;
	private Gamepad myGamepad;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		myKeyboard = Keyboard.current;
		myGamepad = Gamepad.current;
	}

	private void Update()
	{
		valueX = 0;
		valueY = 0;

		if (myKeyboard != null)
		{
			if (myKeyboard.aKey.isPressed)
				valueX = -1;
			if (myKeyboard.dKey.isPressed)
				valueX = 1;
			if (myKeyboard.aKey.isPressed && myKeyboard.dKey.isPressed)
				valueX = 0;

			if (myKeyboard.wKey.isPressed)
				valueY = 1;
			if (myKeyboard.sKey.isPressed)
				valueY = -1;
			if (myKeyboard.wKey.isPressed && myKeyboard.sKey.isPressed)
				valueY = 0;
		}

		if (myGamepad != null)
		{
			gamepadDirection = myGamepad.leftStick.ReadValue();
			valueX = gamepadDirection.x;
			valueY = gamepadDirection.y;
		}

		direction = new Vector2(valueX, valueY).normalized;
	}

	private void FixedUpdate()
	{
		rb.linearVelocity = new Vector2(direction.x * speed, direction.y * speed) * Time.deltaTime;
	}
}

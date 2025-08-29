using UnityEngine;
using UnityEngine.InputSystem;


public class DirectSyntax : MonoBehaviour
{
	private Keyboard myKeyboard;
	private Gamepad myGamepad;
	private Mouse myMouse;

	private void Awake()
	{
		myKeyboard = Keyboard.current;
		myGamepad = Gamepad.current;
		myMouse = Mouse.current;
	}

	private void Update()
	{
		// for the keyboard
		if (myKeyboard != null)
		{
			if (myKeyboard.spaceKey.wasPressedThisFrame)
			{
				Debug.Log("Keyboard Down.");
			}
			if (myKeyboard.spaceKey.wasReleasedThisFrame)
			{
				Debug.Log("Keyboard Up.");
			}
			if (myKeyboard.spaceKey.isPressed)
			{
				Debug.Log("Keyboard Pressed.");
			}
		}

		if (myGamepad != null)
		{
			// ✅ Face Buttons
			if (myGamepad.buttonSouth.wasPressedThisFrame)   // A (Xbox) / X (PS) / B (Nintendo)
				Debug.Log("Button South pressed.");

			if (myGamepad.buttonNorth.wasPressedThisFrame)   // Y (Xbox) / Triangle (PS) / X (Nintendo)
				Debug.Log("Button North pressed.");

			if (myGamepad.buttonEast.wasPressedThisFrame)    // B (Xbox) / Circle (PS) / A (Nintendo)
				Debug.Log("Button East pressed.");

			if (myGamepad.buttonWest.wasPressedThisFrame)    // X (Xbox) / Square (PS) / Y (Nintendo)
				Debug.Log("Button West pressed.");

			// ✅ D-Pad
			if (myGamepad.dpad.up.wasPressedThisFrame)
				Debug.Log("D-Pad Up pressed.");

			if (myGamepad.dpad.down.wasPressedThisFrame)
				Debug.Log("D-Pad Down pressed.");

			if (myGamepad.dpad.left.wasPressedThisFrame)
				Debug.Log("D-Pad Left pressed.");

			if (myGamepad.dpad.right.wasPressedThisFrame)
				Debug.Log("D-Pad Right pressed.");

			// ✅ Shoulder Buttons
			if (myGamepad.leftShoulder.wasPressedThisFrame)   // LB (Xbox) / L1 (PS)
				Debug.Log("Left Shoulder pressed.");

			if (myGamepad.rightShoulder.wasPressedThisFrame)  // RB (Xbox) / R1 (PS)
				Debug.Log("Right Shoulder pressed.");

			// ✅ Trigger Buttons
			if (myGamepad.leftTrigger.wasPressedThisFrame)    // LT (Xbox) / L2 (PS)
				Debug.Log("Left Trigger pressed.");

			if (myGamepad.rightTrigger.wasPressedThisFrame)   // RT (Xbox) / R2 (PS)
				Debug.Log("Right Trigger pressed.");

			// ✅ Stick Press (L3 / R3)
			if (myGamepad.leftStickButton.wasPressedThisFrame)
				Debug.Log("Left Stick Button pressed (L3).");

			if (myGamepad.rightStickButton.wasPressedThisFrame)
				Debug.Log("Right Stick Button pressed (R3).");

			// ✅ Stick Directions (Optional – for analog movement)
			if (myGamepad.leftStick.ReadValue() != Vector2.zero)
				Debug.Log("Left Stick movement: " + myGamepad.leftStick.ReadValue());

			if (myGamepad.rightStick.ReadValue() != Vector2.zero)
				Debug.Log("Right Stick movement: " + myGamepad.rightStick.ReadValue());

			// ✅ Start / Select / Options
			if (myGamepad.startButton.wasPressedThisFrame)     // Menu (Xbox) / Options (PS)
				Debug.Log("Start/Options button pressed.");

			if (myGamepad.selectButton.wasPressedThisFrame)    // View (Xbox) / Share (PS)
				Debug.Log("Select/Share button pressed.");
		}

		if (myMouse != null)
		{
			// ✅ Mouse Buttons
			if (myMouse.leftButton.wasPressedThisFrame)     // Left Click
				Debug.Log("Left Mouse Button pressed.");

			if (myMouse.rightButton.wasPressedThisFrame)    // Right Click
				Debug.Log("Right Mouse Button pressed.");

			if (myMouse.middleButton.wasPressedThisFrame)   // Middle Click (Scroll wheel button)
				Debug.Log("Middle Mouse Button pressed.");

			if (myMouse.forwardButton != null && myMouse.forwardButton.wasPressedThisFrame) // Extra Button (Mouse 4)
				Debug.Log("Forward Mouse Button pressed.");

			if (myMouse.backButton != null && myMouse.backButton.wasPressedThisFrame)       // Extra Button (Mouse 5)
				Debug.Log("Back Mouse Button pressed.");

			//// ✅ Mouse Movement
			//if (myMouse.delta.ReadValue() != Vector2.zero)
			//	Debug.Log("Mouse moved: " + myMouse.delta.ReadValue());

			// ✅ Mouse Position on Screen
			//Debug.Log("Mouse position: " + myMouse.position.ReadValue());

			// ✅ Scroll Wheel
			if (myMouse.scroll.ReadValue() != Vector2.zero)
				Debug.Log("Mouse Scroll: " + myMouse.scroll.ReadValue());

		}
	}
}

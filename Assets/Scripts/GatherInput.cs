using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInput : MonoBehaviour
{
	public static GatherInput Instance;



	#region -------- InspectorRefernceMethod -------------------------
	//public InputActionAsset ActionAsset;

	//private InputAction moveAction;
	//private InputAction jumpAction;
	//private InputAction attackAction;

	//private InputActionMap playerNormal;

	#endregion --------------------------------------------

	private RohanInputAction inputActionAsset;

	public float ValueX;
	public bool TryToJump;
	public bool TryToAttack;

	private void Awake()
	{
		#region ---------------- InspectorRefernceMethod  ---------------------------------
		//playerNormal = ActionAsset.FindActionMap("PlayerNormal");
		//jumpAction = playerNormal.FindAction("Jump");
		//moveAction = playerNormal.FindAction("MoveHorizontal");
		//attackAction = playerNormal.FindAction("Attack");
		#endregion ------------------------------------------------

		if (Instance == null)
		{
			Instance = this;
			inputActionAsset = new RohanInputAction();
		}
	}

	private void OnEnable()
	{
		#region ---------------- InspectorRefernceMethod  ---------------------------------
		//ActionAsset.Enable();
		//jumpAction.performed += JumpExample;
		//jumpAction.canceled += JumpStopExample;
		//attackAction.performed += AttackExample;
		//attackAction.canceled += StopAttackExample;
		#endregion ------------------------------------------------

		inputActionAsset.Enable();
		inputActionAsset.PlayerNormal.Jump.performed += JumpExample;
		inputActionAsset.PlayerNormal.Jump.canceled += JumpStopExample;
		inputActionAsset.PlayerNormal.Attack.performed += AttackExample;
		inputActionAsset.PlayerNormal.Attack.canceled += StopAttackExample;
	}

	private void OnDisable()
	{
		#region ---------------- InspectorRefernceMethod  ---------------------------------
		//ActionAsset.Enable();
		//jumpAction.performed -= JumpExample;
		//jumpAction.canceled -= JumpStopExample;
		//attackAction.performed -= AttackExample;
		//attackAction.canceled -= StopAttackExample;
		#endregion ------------------------------------------------

		inputActionAsset.Disable();
		inputActionAsset.PlayerNormal.Jump.performed -= JumpExample;
		inputActionAsset.PlayerNormal.Jump.canceled -= JumpStopExample;
		inputActionAsset.PlayerNormal.Attack.performed -= AttackExample;
		inputActionAsset.PlayerNormal.Attack.canceled -= StopAttackExample;
	}

	private void Update()
	{
		ValueX = inputActionAsset.PlayerNormal.MoveHorizontal.ReadValue<float>();

		if (ValueX > 0.01)
		{
			ValueX = 1;
		}
		else if (ValueX >= -1 && ValueX < 0)
		{
			ValueX = -1;
		}
		else
		{
			ValueX = 0;
		}

		Debug.Log("ValueX: " + ValueX);
	}

	private void JumpExample(InputAction.CallbackContext value)
	{
		//TryToJump = value.ReadValueAsButton();
		TryToJump = true;
	}

	private void JumpStopExample(InputAction.CallbackContext value)
	{
		//TryToJump = value.ReadValueAsButton();
		TryToJump = false;
	}

	private void AttackExample(InputAction.CallbackContext value)
	{
		TryToAttack = true;
		Debug.Log("Attack");
	}
	private void StopAttackExample(InputAction.CallbackContext value)
	{
		TryToAttack = false;
		Debug.Log("StopAttack");
	}
}

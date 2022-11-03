using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Manager : MonoBehaviour
{
    private float timeSinceJumpPressed = 0f;
    private float timeSinceCrouchPressed = 0f;
    private float timeSinceAtackPressed = 0f;
    private Vector2 leftAxisValue = Vector2.zero;
    private Vector2 mousePosition = Vector2.zero;
    private PlayerInputAction playerInputs;
    public static Input_Manager _INPUT_MANAGER;
    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(_INPUT_MANAGER);
        }
        else
        {
            playerInputs = new PlayerInputAction();
            playerInputs.Character.Enable();

            playerInputs.Character.Jump.performed += JumpButtonPressed;
            playerInputs.Character.Crouch.performed += CrouchButtonPressed;
            playerInputs.Character.Move.performed += LeftAxisUpdate;
            playerInputs.Character.View.performed += MousePositionUpdate;
            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Update()
    {
        timeSinceJumpPressed += Time.deltaTime;
        timeSinceCrouchPressed += Time.deltaTime;
        timeSinceAtackPressed += Time.deltaTime;
        InputSystem.Update();
    }
    public void JumpButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceJumpPressed = 0f;
    }
    public void CrouchButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceCrouchPressed = 0f;
    }
    public void AtackButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceAtackPressed = 0f;
    }
    private void MousePositionUpdate(InputAction.CallbackContext context)
    {
        mousePosition = context.ReadValue<Vector2>();
    }
    
    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();
    }
    public bool GetCrouchButtonPressed()
    {
        return this.timeSinceCrouchPressed == 0f;
    }
    public bool GetSouthButtonPressed()
    {
        return this.timeSinceJumpPressed == 0f;
    }
    public bool GetAtackButtonPressed()
    {
        return this.timeSinceAtackPressed == 0f;
    }
}


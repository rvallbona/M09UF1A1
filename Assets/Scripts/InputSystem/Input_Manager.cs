using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Manager : MonoBehaviour
{
    private float timeSinceJumpPressed = 0f;
    private float timeSinceCrouchPressed = 0f;
    private float timeSinceCappyPressed = 0f;
    private float timeSinceBackflipPressed = 0f; 
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
            playerInputs.Character.Backflip.performed += Backflip;
            playerInputs.Character.Cappy.performed += CappyButtonPressed;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Update()
    {
        timeSinceJumpPressed += Time.deltaTime;
        timeSinceCrouchPressed += Time.deltaTime;
        timeSinceCappyPressed += Time.deltaTime;
        timeSinceBackflipPressed += Time.deltaTime;
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
    public void CappyButtonPressed(InputAction.CallbackContext context)
    {
        timeSinceCappyPressed = 0f;
    }
    public void Backflip(InputAction.CallbackContext context)
    {
        timeSinceBackflipPressed = 0f;
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
    public bool GetCappyButtonPressed()
    {
        return this.timeSinceCappyPressed == 0f;
    }
    public bool GetBackflipButtonPressed()
    {
        return this.timeSinceBackflipPressed == 0f;
    }
}


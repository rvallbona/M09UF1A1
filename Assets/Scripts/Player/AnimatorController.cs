using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class AnimatorController : MonoBehaviour
{
    Animator anim;
    PlayerController playerController;
    private PlayerInputAction playerInputAction;

    private bool groundedPlayer;
    private bool canDoubleJump;
    private bool canTripleJump;

    private bool JumpPress;
    private bool CappyPress;
    private bool CrouchPress;
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
    }
    private void OnEnable()
    {
        playerInputAction.Character.Enable();
    }
    private void OnDisable()
    {
        playerInputAction.Character.Disable();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Inputs();
        AuxVar();

        anim.SetFloat("Speed", playerController.GetVelocity());
        if (groundedPlayer)
        {
            anim.SetBool("Jump", false);
        }
        if (JumpPress && groundedPlayer)
        {
            canDoubleJump = true;
            anim.SetBool("Jump", true);
        }
        else
        {
            if (JumpPress && canDoubleJump && !groundedPlayer)
            {
                canDoubleJump = false;
                canTripleJump = true;
                anim.SetBool("Jump", true);
            }
            else
            {
                if (JumpPress && canTripleJump && !groundedPlayer)
                {
                    canTripleJump = false;
                    anim.SetBool("Jump", true);
                }
            }
        }
        
    }
    void Inputs()
    {
        JumpPress = Input_Manager._INPUT_MANAGER.GetSouthButtonPressed();
        CappyPress = Input_Manager._INPUT_MANAGER.GetCappyButtonPressed();
        CrouchPress = Input_Manager._INPUT_MANAGER.GetCrouchButtonPressed();
    }
    void AuxVar()
    {
        groundedPlayer = playerController.IsGround();
    }
}

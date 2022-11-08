using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private PlayerInputAction playerInputAction;
    private Vector2 moveInput;
    [SerializeField] Camera cam;
    private CharacterController controller;
    [SerializeField]private GameObject player;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private bool Colision;
    private float playerSpeed = 5f;
    private float jumpForce = 1f;
    private float doubleJumpForce = 0.7f;
    private float tripleJumpForce = 0.5f;
    private float wallJumpForce = 0.5f;
    private float timerWallJump = 0f;
    private bool canDoubleJump = false;
    private bool canTripleJump = false;
    private float gravityForce = -9.81f;
    public bool isCrouching;
    public float rotationSpeed = 10f;

    [SerializeField]
    private float platformJumpForce = 2f;
    private float cappyJumpForce = 3f;

    //Anim
    private Animator anim;

    private bool isCrouched;

    private bool JumpPress;
    private bool CappyPress;
    private bool CrouchNoPress;
    private bool CrouchPress;
    private bool BackflipPress;
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
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Gravity();
        Inputs();
        Movement();
        Jump();
        Crouch();

        controller.Move(playerVelocity * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        moveInput = playerInputAction.Character.Move.ReadValue<Vector2>();
    }
    void Inputs()
    {
        JumpPress = Input_Manager._INPUT_MANAGER.GetSouthButtonPressed();
        CappyPress = Input_Manager._INPUT_MANAGER.GetCappyButtonPressed();
        CrouchPress = Input_Manager._INPUT_MANAGER.GetCrouchButtonPressed();
        CrouchNoPress = Input_Manager._INPUT_MANAGER.GetCrouchButtonNoPressed();
        BackflipPress = Input_Manager._INPUT_MANAGER.GetBackflipButtonPressed(); 
    }
    void Gravity()
    {
        groundedPlayer = controller.isGrounded;
        if (!groundedPlayer)
        {
            playerVelocity.y += gravityForce * Time.deltaTime;
        }
        else
        {
            playerVelocity.y = gravityForce * Time.deltaTime;
        }
    }
    void Movement()
    {
        Vector3 direction = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * new Vector3(moveInput.x, 0, moveInput.y);
        direction.Normalize();
        playerVelocity.x = direction.x * playerSpeed;
        playerVelocity.z = direction.z * playerSpeed;
        if (direction != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
            gameObject.transform.forward = direction;
        }
        anim.SetFloat("Speed", controller.velocity.magnitude);
        anim.SetFloat("CrouchSpeed", controller.velocity.magnitude);
        if (groundedPlayer) { anim.SetBool("Jump", false); }
    }

    void Jump()
    {
        if (JumpPress && groundedPlayer)
        {
            canDoubleJump = true;
            Jumping(jumpForce);
            anim.SetBool("Jump", true);
        }
        else 
        {
            if (JumpPress && canDoubleJump && !groundedPlayer)
            {
                canDoubleJump = false;
                canTripleJump = true;
                Jumping(doubleJumpForce);
                anim.SetBool("Jump", true);
            }
            else
            {
                if (JumpPress && canTripleJump && !groundedPlayer)
                {
                    canTripleJump = false;
                    Jumping(tripleJumpForce);
                    anim.SetBool("Jump", true);
                }
            }
        }
        WallJump();
    }
    void WallJump()
    {
        timerWallJump += Time.deltaTime;
        if (!groundedPlayer && controller.collisionFlags == CollisionFlags.Sides)
        {
            if (JumpPress && timerWallJump > 1f)
            {
                Debug.Log("wallJump");
                Jumping(wallJumpForce);
                anim.SetBool("Jump", true);
                timerWallJump = 0;
            }
        }
    }
    void Jumping(float jumpForce)
    {
        playerVelocity.y += Mathf.Sqrt((jumpForce * jumpForce) * -3.0f * gravityForce);
    }
    void Crouch()
    {
        if (CrouchPress)
        {
            Debug.Log(CrouchPress);
            anim.SetBool("Crouch", true);
        }
        if (CrouchNoPress)
        {
            isCrouching = false;
            Debug.Log(isCrouching);
            anim.SetBool("Crouch", false);
        }
    }
    public void PlatformJump()
    {
        Jumping(platformJumpForce);
        anim.SetBool("Jump", true);
    }
    public void CappyJump()
    {
        Jumping(cappyJumpForce);
        anim.SetBool("Jump", true);
    }
    public float GetVelocity()
    {
        return controller.velocity.magnitude;
    }
    public bool IsGround()
    {
        return groundedPlayer;
    }
}
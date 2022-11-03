using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private PlayerInputAction playerInputAction;
    private Vector2 mouseInput;

    [SerializeField]float mouseSensitivity = 3.0f;
    [SerializeField] Transform target;
    [SerializeField] float distanceFromTarget = 5.0f;

    private float rotationX;
    private float rotationY;

    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;
    public float smoothTime = 3.0f;
    [SerializeField] private float cameraLerp = 12f; //12f
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void OnEnable()
    {
        playerInputAction.Character.Enable();
    }
    private void OnDisable()
    {
        playerInputAction.Character.Disable();
    }
    private void FixedUpdate()
    {
        mouseInput = playerInputAction.Character.View.ReadValue<Vector2>();

    }
    void Update()
    {
        rotationX += mouseInput.x * mouseSensitivity;
        rotationY += mouseInput.y * mouseSensitivity;

        rotationY = Mathf.Clamp(rotationY, 9, 90);

        Vector3 nextRotation = new Vector3(rotationY, rotationX);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);

        transform.localEulerAngles = currentRotation;

        transform.position = target.position - transform.forward * distanceFromTarget;
    }
    private void LateUpdate()
    {
        Vector3 finalPosition = Vector3.Lerp(transform.position, target.transform.position - transform.forward * distanceFromTarget, cameraLerp * Time.deltaTime);
        RaycastHit hit;
        if (Physics.Linecast(target.transform.position, finalPosition, out hit))
        {
            finalPosition = hit.point;
        }
        transform.position = finalPosition;
    }
}

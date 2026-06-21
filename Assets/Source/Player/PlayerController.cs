using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public enum RotationBehavior
    {
        FaceMovementDirection,
        FaceMouseCursor
    }

    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private RotationBehavior rotationType = RotationBehavior.FaceMovementDirection;

    [Header("Ground & Gravity Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float gravity = -9.81f;

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    private CharacterController characterController;
    private Camera mainCamera;

    private Vector3 movementInput;
    private Vector3 velocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    private void Update()
    {
        GatherInput();
        ProcessMovement();
        ProcessRotation();
    }

    private void GatherInput()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();

        movementInput = new Vector3(
            input.x,
            input.y,
            0f
        );

        if (movementInput.sqrMagnitude > 1f)
            movementInput.Normalize();
    }


    private void ProcessMovement()
    {
        characterController.Move(
            movementInput * moveSpeed * Time.deltaTime
        );
    }

    private void ProcessRotation()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        Ray ray = mainCamera.ScreenPointToRay(mousePos);

        Plane groundPlane = new Plane(Vector3.up, transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);

            Vector3 lookDir = hitPoint - transform.position;
            lookDir.y = 0f;

            if (lookDir.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation =
                    Quaternion.LookRotation(lookDir);

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    targetRotation,
                    rotationSpeed * Time.deltaTime
                );
            }
        }
    }
}
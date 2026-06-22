using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float minLookDistance = 0.1f; // ignore cursor too close to player

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private float targetAngle;
    private bool hasValidLookDir;

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true; // <-- key fix: physics must never rotate this body
    }

    private void OnEnable() => moveAction.action.Enable();
    private void OnDisable() => moveAction.action.Disable();

    private void Update()
    {
        movementInput = moveAction.action.ReadValue<Vector2>();

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorld.z = 0f;

        Vector2 lookDir = mouseWorld - transform.position;

        // Use a real-world distance threshold, not a tiny sqrMagnitude epsilon
        if (lookDir.sqrMagnitude > minLookDistance * minLookDistance)
        {
            targetAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            hasValidLookDir = true;
        }
        // else: keep last valid targetAngle, don't rotate toward noise
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput.normalized * moveSpeed;

        if (hasValidLookDir)
        {
            float newAngle = Mathf.LerpAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(newAngle);
        }
    }
}
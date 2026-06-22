using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float minLookDistance = 0.1f;

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    [Header("Gambling")]
    [SerializeField] private float GoodLuckMultiplier = 1.0f;


    private Rigidbody2D rb;
    private Health health;
    private Vector2 movementInput;
    private float targetAngle;
    private bool hasValidLookDir;
    private bool mouseLookEnabled = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();

        rb.gravityScale = 0;
        rb.freezeRotation = true;

        health.Died += OnDied;
        health.Damaged += OnDamaged;
        health.Healed += OnHealed;

        ControllerRegistry.Register(this);
    }

    private void OnEnable() => moveAction.action.Enable();
    private void OnDisable() => moveAction.action.Disable();

    private void Update()
    {
        movementInput = moveAction.action.ReadValue<Vector2>();

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseWorld.z = 0f;

        Vector2 lookDir = mouseWorld - transform.position;

        if (mouseLookEnabled && lookDir.sqrMagnitude > minLookDistance * minLookDistance)
        {
            targetAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
            hasValidLookDir = true;
        }
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
    private void OnDied()
    {
        mouseLookEnabled = false;
        movementInput = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
        Debug.Log("Player died");
        // disable input, trigger death anim, load game over screen, etc.
    }

    private void OnDamaged(float amount, float current)
    {
        Debug.Log($"Player took {amount} damage, {current} HP remaining");
        //  update HP bar
    }

    private void OnHealed(float amount, float current)
    {
        Debug.Log($"Player healed {amount}, now at {current} HP");
        // update HP bar
    }

    public Transform GetTransform() => transform;
    public InputActionReference GetInputActionReference() => moveAction;
    public Rigidbody2D GetRigidbody() => rb;

    public float GetMoveSpeed() => moveSpeed;
    public void SetMoveSpeed(float v) => moveSpeed = v;

    public float GetGoodLuckMultiplier() => GoodLuckMultiplier;
    public void SetGoodLuckMultiplier(float v) => GoodLuckMultiplier = v;


    public float GetMaxHealth() => health.GetMaxHealth();
    public void SetMaxHealth(int v) => health.SetMaxHealth(v);
    public float GetRegenSpeed() => health.GetRegenSpeed();
    public void SetRegenSpeed(float v) => health.SetRegenSpeed(v);
}
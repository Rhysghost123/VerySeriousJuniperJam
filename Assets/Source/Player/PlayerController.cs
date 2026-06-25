using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float minLookDistance = 0.1f; // ignore cursor too close to player

    [Header("Input")]
    [SerializeField] private InputActionReference moveAction;

    [Header("GAMBLING")]
    [SerializeField] private float GoodLuckMultiplier = 1.0f;

    [Header("Health")]
    [SerializeField] private float MaxHealth = 100;
    [SerializeField] private float CurrentHealth = 100;
    [SerializeField] private float RegenSpeed = 5.0f; // per second

    [Header("Legs lol")]
    [SerializeField] private GameObject legs;
    [SerializeField] private GameObject legsSecondary;
    [SerializeField] private GameObject legsTertiary;
    private Animator anim;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private float targetAngle;
    private bool hasValidLookDir;

    private bool mouseLookEnabled { get; set; } = true;

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
    public void SetGoodLuckMultiplier(float mul)
    {
        GoodLuckMultiplier = mul;
    }
    public float GetGoodLuckMultiplier()
    {
        return GoodLuckMultiplier;
    }

    public void SetMaxHealth(float val)
    {
        MaxHealth = val;
    }
    public float GetMaxHealth()
    {
        return MaxHealth;
    }
    public void SetCurrentHealth(float val)
    {
        CurrentHealth = val;
    }
    public float GetCurrentHealth()
    {
        return CurrentHealth;
    }
    public void SetRegenSpeed(float val)
    {
        RegenSpeed = val;
    }
    public float GetRegenSpeed()
    {
        return RegenSpeed;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true; // <-- key fix: physics must never rotate this body
        anim = legs.GetComponent<Animator>();
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
        if (mouseLookEnabled == true && lookDir.sqrMagnitude > minLookDistance * minLookDistance)
        {
            targetAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            hasValidLookDir = true;
        }
        // else: keep last valid targetAngle, don't rotate toward noise

        if(movementInput == Vector2.zero)
        {
           legsSecondary.SetActive(true);
           legsTertiary.SetActive(true);
           anim.SetBool("IsMoving", false);
        }
        else
        {
            legsSecondary.SetActive(false);
            legsTertiary.SetActive(false);
            anim.SetBool("IsMoving", true);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementInput.normalized * moveSpeed;
        legs.transform.position = gameObject.transform.position;
        legsSecondary.transform.position = gameObject.transform.position;
        legsTertiary.transform.position = gameObject.transform.position;
        
        //aligns legs in the same direction as the movementInput vector
        AlignLegsWithMovement(movementInput);


        if (hasValidLookDir)
        {
            float newAngle = Mathf.LerpAngle(rb.rotation, targetAngle, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(newAngle);
        }

        if (CurrentHealth <= 0)
        {
            playerDeath();
        }
    }

    private void playerDeath()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void AlignLegsWithMovement(Vector2 movementInput)
    {
    if (movementInput == Vector2.zero) return; // No movement, keep legs as-is

    // Calculate the angle from the movement input along the Z axis
    float angle = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;

    // Apply the rotation to the legs bone/object along the Z axis
    Quaternion targetRotation = Quaternion.Euler(0f, 0f, -angle);
    legs.transform.rotation = Quaternion.Slerp(legs.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    legsSecondary.transform.rotation = Quaternion.Slerp(legsSecondary.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    legsTertiary.transform.rotation = Quaternion.Slerp(legsTertiary.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
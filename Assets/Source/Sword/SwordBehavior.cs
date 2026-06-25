using UnityEngine;
using UnityEngine.InputSystem;

public class SwordBehavior : MonoBehaviour
{
    public MeleeWeapon meleeWeapon;
    public GameObject player;

    [Header("Sword Arc Settings")]
    [SerializeField] float orbitRadius;

    [Header("Heavy Weapon Feel")]
    [SerializeField] float rotationAcceleration = 12f;
    [SerializeField] float angularDrag = 6f;

    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private Camera mainCam;

    private float currentAngle;
    private float angularVelocity;

    void Start()
    {
        mainCam = Camera.main;
        playerRb = player.GetComponent<Rigidbody2D>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        // Initialize currentAngle to the player's current rotation
        // so the sword doesn't snap on the first frame
        currentAngle = playerRb.rotation;
    }

    void Update()
    {
        AdjustSwordPos();
    }

    void AdjustSwordPos()
    {
        if (Mouse.current == null) return;

        Vector2 mousePos = (Vector2) mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 offset = mousePos - (Vector2)player.transform.position;
        float targetAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        // Find the shortest arc to the target angle, handles 0/360 wraparound
        float angleDiff = Mathf.DeltaAngle(currentAngle, targetAngle);

        // Accelerate toward target angle, then bleed off speed with drag
        angularVelocity += angleDiff * rotationAcceleration * Time.deltaTime;
        angularVelocity *= Mathf.Clamp01(1f - angularDrag * Time.deltaTime);
        currentAngle += angularVelocity * Time.deltaTime;

        // Position sword around player at current angle
        float angleRad = currentAngle * Mathf.Deg2Rad;
        Vector2 swordOffset = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * orbitRadius;
        transform.position = (Vector2)player.transform.position + swordOffset;

        // Rotate sword and player sprite to match
        Quaternion rot = Quaternion.Euler(0f, 0f, currentAngle);
        transform.rotation = rot;
        playerSprite.transform.rotation = Quaternion.Euler(0f, 0f, currentAngle - 90f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyComponent enemyHealth = other.gameObject.GetComponent<EnemyComponent>();

            if (enemyHealth != null)
            {
                Vector2 knockbackDir = (other.transform.position - player.transform.position).normalized;
                enemyHealth.TakeDamage(meleeWeapon.damage, meleeWeapon.weight, knockbackDir);
                print("Enemy hit for " + meleeWeapon.damage + " damage.");
            }
        }
    }
}
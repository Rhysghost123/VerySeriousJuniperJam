using System;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordBehavior : MonoBehaviour
{
    public MeleeWeapon meleeWeapon;
    public GameObject player;

    [Header("Sword Arc Settings")]
    [SerializeField] float orbitSpeed = 2f;
    [SerializeField] float orbitRadius;

    // Reinstated missing fields
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSprite;
    private float orbitAngle;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        adjustSwordPos();
    }

    void adjustSwordPos()
    {
        Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 offset = mousePos - (Vector2)player.transform.position;

        offset = offset.normalized * orbitRadius;
        transform.position = (Vector2)player.transform.position + offset;

        transform.right = player.transform.position - transform.position;
        player.transform.right = transform.right;

        // Spin the player sprite with the sword
        playerSprite.transform.rotation = Quaternion.Euler(0f, 0f, orbitAngle * Mathf.Rad2Deg);
    }

    private void HoldAtForward()
    {
        float playerAngleRad = playerRb.rotation * Mathf.Deg2Rad;
        orbitAngle = playerAngleRad;
        SetPositionAtAngle(orbitAngle);

        // Restore sprite to match actual player rotation
        playerSprite.transform.rotation = Quaternion.Euler(0f, 0f, playerRb.rotation);
    }

    private void SetPositionAtAngle(float angleRad)
    {
        Vector2 offset = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * orbitRadius;
        transform.position = playerSprite.transform.position + (Vector3)offset;

        transform.rotation = Quaternion.Euler(0f, 0f, angleRad * Mathf.Rad2Deg + 180f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Sword hit something.");
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyComponent enemyHealth = other.gameObject.GetComponent<EnemyComponent>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(
                    meleeWeapon.damage,
                    meleeWeapon.weight,
                    other.gameObject.transform.position - playerRb.gameObject.transform.position
                );

                print("Enemy hit for " + meleeWeapon.damage + " damage.");
            }
        }
    }
}
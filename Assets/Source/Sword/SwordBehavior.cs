using System;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwordBehavior : MonoBehaviour
{
    public MeleeWeapon meleeWeapon;
    public GameObject playerSprite;
    public InputActionReference reference;

    [Header("Sword Arc Settings")]
    [SerializeField] float orbitSpeed = 2f;   // radians per second
    [SerializeField] float orbitRadius;

    private void OnEnable() => reference.action.Enable();
    private void OnDisable() => reference.action.Disable();

    private float orbitAngle;
    private Rigidbody2D playerRb;


    private void Start()
    {
        playerRb = PlayerUtils.GetPlayerController().GetRigidbody();
    }

    private void Update()
    {
        if (reference.action.IsPressed())
            Orbit();
        else
            HoldAtForward();
    }

    private void Orbit()
    {
        orbitAngle += orbitSpeed * Time.deltaTime;
        SetPositionAtAngle(orbitAngle);

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

        transform.rotation = Quaternion.Euler(0f, 0f, angleRad * Mathf.Rad2Deg + 180f); // +180 flips sprite to face outward
    }
}

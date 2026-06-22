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

    private float _orbitAngle;
    private Rigidbody2D _playerRb;


    private void Start()
    {
        _playerRb = PlayerUtils.GetPlayerController().GetRigidbody();
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
        _orbitAngle += orbitSpeed * Time.deltaTime;
        SetPositionAtAngle(_orbitAngle);

        // Spin the player sprite with the sword
        playerSprite.transform.rotation = Quaternion.Euler(0f, 0f, _orbitAngle * Mathf.Rad2Deg);
    }

    private void HoldAtForward()
    {
        float playerAngleRad = _playerRb.rotation * Mathf.Deg2Rad;
        _orbitAngle = playerAngleRad;
        SetPositionAtAngle(_orbitAngle);

        // Restore sprite to match actual player rotation
        playerSprite.transform.rotation = Quaternion.Euler(0f, 0f, _playerRb.rotation);
    }

    private void SetPositionAtAngle(float angleRad)
    {
        Vector2 offset = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * orbitRadius;
        transform.position = playerSprite.transform.position + (Vector3)offset;

        transform.rotation = Quaternion.Euler(0f, 0f, angleRad * Mathf.Rad2Deg + 180f); // +180 flips sprite to face outward
    }
}

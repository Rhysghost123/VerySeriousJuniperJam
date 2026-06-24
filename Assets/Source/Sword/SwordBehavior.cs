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
    [SerializeField] float orbitSpeed = 2f;   // radians per second
    [SerializeField] float orbitRadius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     adjustSwordPos();
    }

    //get a vector from player to mous pos, normalize it, multiply by orbit radius
 
 void adjustSwordPos()
    {
       //get a vector in the direction I want the sword to be in away from the player
        Vector2 mousePos = (Vector2) Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 offset = mousePos - (Vector2) player.transform.position;

        //normalize it and then multiply by a set radius so we can have the sword at an arbitrary distance from player,
        //and then make the position the player's + the offset
        offset = offset.normalized * orbitRadius;
        transform.position = (Vector2) player.transform.position + offset;
        
        //make the object's x axis the direction of the vector so it faces the player, and rotate the player
        transform.right = player.transform.position - transform.position;
        player.transform.right = transform.right;


<<<<<<< Updated upstream
    }
    
    
=======
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
        transform.position = playerSprite.transform.position + (Vector3) offset;

        transform.rotation = Quaternion.Euler(0f, 0f, angleRad * Mathf.Rad2Deg + 180f); // +180 flips sprite to face outward
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Sword hit something.");
        if (other.gameObject.CompareTag("Enemy")) //if the collision is with an enemy
        {
            EnemyComponent enemyHealth = other.gameObject.GetComponent<EnemyComponent>();

            if (enemyHealth != null) //and it has a health component
            {
                enemyHealth.TakeDamage(
                meleeWeapon.damage,
                meleeWeapon.weight,
                other.gameObject.transform.position - playerRb.gameObject.transform.position
                ); //damage it using the player's strength and the sword's damage ADD PLAYER STRENGTH TO THIS MULTIPLIER

                print("Enemy hit for " + meleeWeapon.damage + " damage.");

            }
            
        }
    }

   
>>>>>>> Stashed changes
}

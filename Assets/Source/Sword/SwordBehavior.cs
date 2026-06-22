using System;
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


    }
    
    
}

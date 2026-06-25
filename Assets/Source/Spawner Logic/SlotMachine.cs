using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlotMachine : MonoBehaviour
{
    
    private GameObject player;
    public float interactRng;
    public InputActionAsset inputActions;

    private InputAction interactAction;

    
    private Transform playerTransform;

    
    private bool hasBeenActivated = false;

    private void Awake()
    {
        interactAction = InputSystem.actions.FindAction("Interact");
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
            playerTransform = player.GetComponent<Transform>();
    }


    void Update()
    {
        
        if (hasBeenActivated) return;

        if (playerTransform == null) return;

        Vector2 playerPosition = playerTransform.position;
        Vector2 objectPosition = transform.position;

       
        
        float distance = Vector2.Distance(playerPosition, objectPosition);

       
        
        if (distance < interactRng && interactAction.WasPressedThisFrame())
        {
            hasBeenActivated = true;
            GameManager.instance.phase = 1;
            GameManager.instance.StartCoroutine(GameManager.instance.SpawnEnemies());

            Destroy(gameObject);
        }
    }
}
using System;
using Unity.VisualScripting;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{

    [SerializeField] private float damage = 20f;
    private void OnTriggerEnter(Collider other)
    {
        EnemyHealth health = other.GetComponent<EnemyHealth>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
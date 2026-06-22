using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    IndividualAttack,
    GangAttack,
    GangRetreat
}

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Health))]
public class EnemyController : MonoBehaviour
{
    private static readonly HashSet<EnemyController> gang = new();
    private static int gangInitialSize;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void ResetGang() { gang.Clear(); gangInitialSize = 0; }

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 4f;

    [Header("Combat")]
    [SerializeField] private float attackRange = 1.2f;
    [SerializeField] private float attackCooldown = 1.5f;

    [Header("Stats")]
    [SerializeField] private float strength = 10f;

    [Header("Retreat")]
    [SerializeField] private float retreatDistance = 10f;
    [SerializeField] private Transform retreatWaypoint;

    [Header("Separation")]
    [SerializeField] private float separationRadius = 1.5f;
    [SerializeField] private float separationForce = 3f;


    public float GetMaxHealth() => health.GetMaxHealth();
    public void SetMaxHealth(int v) => health.SetMaxHealth(v);   // BuffManager calls int version
    public float GetRegenSpeed() => health.GetRegenSpeed();
    public void SetRegenSpeed(float v) => health.SetRegenSpeed(v);
    public float GetStrength() => strength;
    public void SetStrength(float v) => strength = v;

    public EnemyState State { get; private set; }

    private Rigidbody2D rb;
    private Transform player;
    private float attackTimer;
    private bool dead;

    private Health health;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();       // was missing
        player = PlayerUtils.GetPlayerController()?.GetTransform();
        ControllerRegistry.Register(this);
        health.Died += OnDied;                     // hook death to existing Die() logic
    }

    private void OnEnable()
    {
        gang.Add(this);
        gangInitialSize = Mathf.Max(gangInitialSize, gang.Count);
        RefreshAllStates();
    }

    private void OnDisable()
    {
        gang.Remove(this);
        RefreshAllStates();
    }

    private void Update()
    {
        if (dead || player == null) return;
        attackTimer -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (dead || player == null) return;

        switch (State)
        {
            case EnemyState.IndividualAttack:
            case EnemyState.GangAttack:
                ChaseAndAttack();
                break;

            case EnemyState.GangRetreat:
                Retreat();
                break;
        }
    }
    private Vector2 GetSeparationVector()
    {
        Vector2 push = Vector2.zero;

        foreach (var other in gang)
        {
            if (other == this) continue;

            Vector2 away = rb.position - other.rb.position;
            float dist = away.magnitude;

            if (dist < separationRadius && dist > 0.001f)
            {
                // closer enemies push harder
                push += away.normalized * (1f - dist / separationRadius);
            }
        }

        return push * separationForce;
    }
    private static void RefreshAllStates()
    {
        foreach (var e in gang)
            e.RecalcState();
    }

    private void RecalcState()
    {
        int alive = gang.Count;

        State = alive switch
        {
            1 => EnemyState.IndividualAttack,
            _ when alive <= gangInitialSize / 2 => EnemyState.GangRetreat,
            _ => EnemyState.GangAttack
        };
    }

    private void ChaseAndAttack()
    {
        Vector2 toPlayer = (Vector2)player.position - rb.position;
        float dist = toPlayer.magnitude;

        if (dist > attackRange)
        {
            Vector2 chaseDir = toPlayer.normalized * moveSpeed;
            Vector2 separation = GetSeparationVector();

            rb.linearVelocity = chaseDir + separation; // separation nudges them apart while still chasing
        }
        else
        {
            rb.linearVelocity = Vector2.zero;

            if (attackTimer <= 0f)
            {
                attackTimer = attackCooldown;
                PerformAttack();
            }
        }
    }

    private void Retreat()
    {
        Vector2 dest = retreatWaypoint != null
            ? (Vector2)retreatWaypoint.position
            : rb.position + ((Vector2)transform.position - (Vector2)player.position).normalized * retreatDistance;

        Vector2 dir = (dest - rb.position).normalized;
        rb.linearVelocity = dir * moveSpeed;
    }

    private void PerformAttack()
    {
        Debug.Log($"{name} hits player for {strength} damage");
        // player.GetComponent<Health>()?.TakeDamage(strength);
    }

    public void Die()
    {
        if (dead) return;
        dead = true;
        rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);
        Destroy(gameObject, 0.1f);
    }
    private void OnDied()
    {
        Die();
    }
}
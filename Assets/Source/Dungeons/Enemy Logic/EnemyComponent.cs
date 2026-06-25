using UnityEngine;
using System.Collections;

public class EnemyComponent : MonoBehaviour
{
    [Header("Follow")]
    [SerializeField] private float moveSpeed = 5f;
    GameObject playerObj;

    private Transform player;

     [Header("Health")]
    [SerializeField] private float maxHealth = 100f;


    [Header("Health Bar Fill")]
    [SerializeField] private Transform Fill;

    private float currentHealth;
    private Rigidbody2D rb;

    [Header("MeleeAttack Details")]
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackCooldown;
    private float lastAttackTime = -Mathf.Infinity;

    //find the player object
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        rb = GetComponent<Rigidbody2D>();


        playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogError("Player not found");
        }
    }

    //follows the player object
    private void Update()
    {
        followPlayer();
        //continue logic to approach the player at a range, and fire at them
    }

    private void followPlayer()
{
    if (player == null) return;

    Vector3 targetPos = player.position;
    targetPos.z = transform.position.z;

    float distance = Vector3.Distance(transform.position, targetPos);

    if (distance > attackRange)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            moveSpeed * Time.deltaTime
        );
    }
    else
    {
        print("Attacking player!");
        AttackPlayer();
    }
}

    public void TakeDamage(float damage, float knockbackForce, Vector2 knockbackDirection)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
        StartCoroutine(SimulateKnockback(knockbackDirection, knockbackForce * 10));
    }

     private void UpdateHealthBar()
    {
        if (Fill == null) return;

        float healthPercent = currentHealth / maxHealth;

        Fill.localScale = new Vector3(
            healthPercent,
            Fill.localScale.y,
            Fill.localScale.z
        );

        float offset = (1f - healthPercent) * 0.5f;

        Fill.localPosition = new Vector3(
            -offset,
            Fill.localPosition.y,
            Fill.localPosition.z
        );
    }

     private void Die()
    {
        EnemySpawner.activeEnemies --;
        Destroy(gameObject);
    }

    IEnumerator SimulateKnockback(Vector2 direction, float force)
    {
        print("added force!");
        rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        rb.linearVelocity = Vector2.zero;
    }

    private void AttackPlayer()
{
    if (Time.time < lastAttackTime + attackCooldown) return;

    lastAttackTime = Time.time;

    PlayerController pc = playerObj.GetComponent<PlayerController>();
    if (pc == null) return;

    pc.SetCurrentHealth(pc.GetCurrentHealth() - attackDamage);
    Debug.Log($"Enemy attacked player for {attackDamage} damage.");
}


}
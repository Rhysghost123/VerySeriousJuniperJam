using UnityEngine;

public class GrapeannonComponent : EnemyComponent
{

    [Header("Ranged Attack")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 8f;

    protected override void followPlayer()
    {
        if (player == null) return;

        Vector3 targetPos = new Vector3(player.position.x, player.position.y, transform.position.z);
        float distance = Vector3.Distance(transform.position, targetPos);

        if (distance > attackRange)
        {
            // Close in until within attack range
            transform.position = Vector3.MoveTowards(
                transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
            AttackPlayer();
    }

    protected override void AttackPlayer()
    {
        if (Time.time < lastAttackTime + attackCooldown) return;
        lastAttackTime = Time.time;

        if (projectilePrefab == null || player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;

        GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D projRb = proj.GetComponent<Rigidbody2D>();
        if (projRb != null)
            projRb.linearVelocity = direction * projectileSpeed;

        GrapeBullet grapeBullet = proj.GetComponent<GrapeBullet>();
        if (grapeBullet != null)
            grapeBullet.SetAttackDamage(base.attackDamage);
        
    }
}

    




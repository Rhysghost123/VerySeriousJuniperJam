using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float maxHealth = 100f;

    [SerializeField] private GameObject enemy;

    [Header("Health Bar Fill")]
    [SerializeField] private Transform Fill;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    //public damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    //updates the health bar
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
        Destroy(enemy);
    }
}
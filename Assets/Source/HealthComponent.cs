using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float regenSpeed = 5f;   // HP per second

    [Header("Events")]
    public UnityEvent<float, float> OnDamaged;   // (damage, currentHp)
    public UnityEvent<float, float> OnHealed;    // (amount, currentHp)
    public UnityEvent OnDeath;

    // C# events for code-side listeners (BuffManager, UI, etc.)
    public event Action<float, float> Damaged;   // (damage, currentHp)
    public event Action<float, float> Healed;    // (amount, currentHp)
    public event Action Died;

    public float Current { get; private set; }
    public float Max => maxHealth;
    public bool IsDead { get; private set; }
    public float Fraction => maxHealth > 0 ? Current / maxHealth : 0f;

    private void Awake() => Current = maxHealth;

    private void Update()
    {
        if (IsDead || regenSpeed <= 0f || Current >= maxHealth) return;
        Heal(regenSpeed * Time.deltaTime);
    }




    public void TakeDamage(float amount)
    {
        if (IsDead || amount <= 0f) return;

        Current = Mathf.Max(Current - amount, 0f);
        OnDamaged?.Invoke(amount, Current);
        Damaged?.Invoke(amount, Current);

        if (Current <= 0f) Kill();
    }

    public void Heal(float amount)
    {
        if (IsDead || amount <= 0f) return;

        float before = Current;
        Current = Mathf.Min(Current + amount, maxHealth);
        float actual = Current - before;

        if (actual > 0f)
        {
            OnHealed?.Invoke(actual, Current);
            Healed?.Invoke(actual, Current);
        }
    }

    public void Kill()
    {
        if (IsDead) return;
        IsDead = true;
        Current = 0f;
        OnDeath?.Invoke();
        Died?.Invoke();
    }

    // give player a chance to revive if they spin a wheel?
    public void Revive(float? withHp = null)
    {
        IsDead = false;
        Current = Mathf.Clamp(withHp ?? maxHealth, 0f, maxHealth);
    }




    public float GetMaxHealth() => maxHealth;
    public float GetRegenSpeed() => regenSpeed;

    public void SetMaxHealth(float v)
    {
        float ratio = Fraction; // preserve HP% when max changes
        maxHealth = Mathf.Max(v, 1f);
        Current = Mathf.Clamp(maxHealth * ratio, 0f, maxHealth);
    }

    public void SetRegenSpeed(float v) => regenSpeed = Mathf.Max(v, 0f);
}
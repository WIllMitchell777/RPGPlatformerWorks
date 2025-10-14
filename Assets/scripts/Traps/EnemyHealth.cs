using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;

    private float currentHealth = 3f;

    public bool HasTakenDamage { get; set; }

    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void Damage(float damageAmount)
    {
        HasTakenDamage = true;

        currentHealth -= damageAmount;

        if(currentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        
    }
}

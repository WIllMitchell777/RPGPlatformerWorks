using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;
    [SerializeField] EnemyHealthBar healthBar;

    private float currentHealth = 3f;

    [Header("Health Settings")]
    public int enemyHealth = 100;

    [Header("Drop Settings")]
    public GameObject healthCollectiblePrefab; // Assign your prefab in the Inspector
    [Range(0f, 1f)]
    public float dropChance = 1f; // 1 = always drop, 0.5 = 50% chance, etc.

    [Header("Drop Offset")]
    public Vector2 dropOffset = new Vector2(0, 0.5f); // Adjust spawn height


    public bool HasTakenDamage { get; set; }

    private void Awake()
    {
        healthBar = GetComponentInChildren<EnemyHealthBar>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
    }
    public void Damage(float damageAmount)
    {
        HasTakenDamage = true;

        currentHealth -= damageAmount;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);

        if(currentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (currentHealth <= 0)
        {

            if (healthCollectiblePrefab != null && Random.value <= dropChance)
            {
                Vector3 dropPosition = transform.position + (Vector3)dropOffset;
                Instantiate(healthCollectiblePrefab, dropPosition, Quaternion.identity);
            }
            Destroy(gameObject);
        }

        
    }
}

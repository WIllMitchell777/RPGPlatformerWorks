using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 10;
    private static PlayerStats instance;

    void Awake()
    {

        currentHealth = maxHealth;
        DontDestroyOnLoad(gameObject);
        
    }

    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;  // optionally heal too


    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }


}


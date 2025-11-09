using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;

    int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage. HP: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Later: play animation / effects
        Destroy(gameObject);
    }
}

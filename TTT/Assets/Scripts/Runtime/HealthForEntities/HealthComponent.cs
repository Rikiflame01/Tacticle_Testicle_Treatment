using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // UnityEvent that will be invoked when health changes
    public UnityEvent<int> OnHealthChanged;

    // UnityEvent that will be invoked when the entity dies
    public UnityEvent OnDied;

    private HealthBarUI healthBarUI; // Reference to the health bar UI

    private void Awake()
    {
        currentHealth = maxHealth;

        // Check if this script is attached to the player
        if (gameObject.CompareTag("Player"))
        {
            // Find the HealthBarUI in the scene
            healthBarUI = FindObjectOfType<HealthBarUI>();

            // Subscribe to the OnHealthChanged event
            OnHealthChanged.AddListener(healthBarUI.UpdateHealthBar);
        }

        OnHealthChanged?.Invoke(currentHealth);


    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        OnDied?.Invoke();
    }
}

using UnityEngine;

public class EnemyDeathActions : MonoBehaviour
{
    private HealthComponent healthComponent;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();

        healthComponent.OnDied.AddListener(HandleDeath);
    }

    private void OnDestroy()
    {
        healthComponent.OnDied.RemoveListener(HandleDeath);
    }

    private void HandleDeath()
    {
        Destroy(gameObject);

        // Optionally, spawn loot, play a sound, or trigger any other behavior here.
    }
}

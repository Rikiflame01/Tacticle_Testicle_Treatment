using UnityEngine;
using UnityEngine.Events;

public class PlayerDeathHandler : MonoBehaviour
{
    private HealthComponent healthComponent;

    // UnityEvent that will be invoked when the player dies
    public UnityEvent OnPlayerDied;

    private void Start()
    {
        // Check if this GameObject is tagged as "Player"
        if (gameObject.CompareTag("Player"))
        {
            // Get the HealthComponent from the player
            healthComponent = GetComponent<HealthComponent>();

            // Null check and then subscribe to the OnDied event
            if (healthComponent)
            {
                healthComponent.OnDied.AddListener(HandlePlayerDeath);
            }
            else
            {
                Debug.LogError("No HealthComponent found on the Player GameObject!");
            }
        }
    }

    private void OnDestroy()
    {
        // If this GameObject is tagged as "Player", unsubscribe from the OnDied event
        if (gameObject.CompareTag("Player") && healthComponent)
        {
            healthComponent.OnDied.RemoveListener(HandlePlayerDeath);
        }
    }

    private void HandlePlayerDeath()
    {
        SFXManager.Instance.PlaySFX(SFXManager.Instance.playerDeath);
        OnPlayerDied?.Invoke();
    }
}

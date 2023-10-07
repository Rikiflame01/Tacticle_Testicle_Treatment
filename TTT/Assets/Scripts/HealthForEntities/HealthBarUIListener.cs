using UnityEngine;

public class HealthBarUIListener : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private HealthBarUI healthBarUI;

    private void Awake()
    {
        if (healthComponent && healthBarUI)
        {
            healthComponent.OnHealthChanged.AddListener(healthBarUI.UpdateHealthBar);
        }
    }
}
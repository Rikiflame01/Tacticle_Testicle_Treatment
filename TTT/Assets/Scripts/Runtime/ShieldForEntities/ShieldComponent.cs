using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldComponent : MonoBehaviour
{
    public int maxShield = 100;
    private int currentShield;

    // UnityEvent that will be invoked when shield changes
    public UnityEvent<int> OnShieldChanged;

    private ShieldBarUI shieldBarUI;

    private void Awake()
    {
        currentShield = maxShield;

        if (gameObject.CompareTag("Player"))
        {
            shieldBarUI = FindObjectOfType<ShieldBarUI>();

            // Subscribe to the OnShieldChanged event
            OnShieldChanged.AddListener(shieldBarUI.UpdateShieldBar);
        }

        OnShieldChanged?.Invoke(currentShield);
    }

    public void ModifyShield(int amount)
    {
        currentShield += amount;
        currentShield = Mathf.Clamp(currentShield, 0, maxShield); 

        OnShieldChanged?.Invoke(currentShield);
    }
}

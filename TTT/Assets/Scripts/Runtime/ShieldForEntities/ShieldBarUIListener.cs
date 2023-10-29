using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBarUIListener : MonoBehaviour
{
    [SerializeField] private ShieldComponent shieldComponent;
    [SerializeField] private ShieldBarUI shieldBarUI;

    private void Awake()
    {
        if (shieldComponent && shieldBarUI)
        {
            shieldComponent.OnShieldChanged.AddListener(shieldBarUI.UpdateShieldBar);
        }
    }
}

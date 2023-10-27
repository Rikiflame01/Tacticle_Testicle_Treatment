using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ShieldComponent shieldComponent;
    public HealthComponent healthComponent;

    public void IncreaseHealth(int amount)
    {
        healthComponent.TakeDamage(-amount); 
    }

    public void IncreaseShield(int amount)
    {
        shieldComponent.ModifyShield(amount);
    }
}

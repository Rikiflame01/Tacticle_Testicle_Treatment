using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup
{
    public int healthAmount = 25;

    public override void OnPickup(Player player)
    {
        player.IncreaseHealth(healthAmount);
    }
}
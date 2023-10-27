using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickup : Pickup
{
    public int shieldAmount = 25;

    public override void OnPickup(Player player)
    {
        player.IncreaseShield(shieldAmount);
    }
}
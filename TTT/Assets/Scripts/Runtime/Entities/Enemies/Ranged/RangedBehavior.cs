using UnityEngine;

public class RangedBehavior : BaseEnemyBehavior
{
    public RangedBehavior(EnemyController controller) : base(controller) { }

    public override void HandleBehavior()
    {
        if (Sight.IsPlayerInSight(controller.transform, player, controller.sightRange))
        {
            // Implement logic to keep distance and attack
        }
        else
        {
            patrolBehavior.Patrol();
        }
    }
}

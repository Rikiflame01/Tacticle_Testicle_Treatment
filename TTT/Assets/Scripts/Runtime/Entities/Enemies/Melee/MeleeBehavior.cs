using UnityEngine;

public class MeleeBehavior : BaseEnemyBehavior
{
    public MeleeBehavior(EnemyController controller) : base(controller) { }

    public override void HandleBehavior()
    {
        if (Sight.IsPlayerInSight(controller.transform, player, controller.sightRange))
        {
            agent.SetDestination(player.position);
        }
        else
        {
            patrolBehavior.Patrol();
        }
    }
}

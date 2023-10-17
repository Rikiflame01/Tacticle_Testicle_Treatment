using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior
{
    private NavMeshAgent agent;
    private Transform[] patrolPoints;
    private int currentPatrolIndex = 0;
    private int direction = 1; // 1 for forward, -1 for backward

    public PatrolBehavior(NavMeshAgent agent, Transform[] patrolPoints)
    {
        this.agent = agent;
        this.patrolPoints = patrolPoints;
    }

    public void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);

            // If we've reached the last point, change direction to backward
            if (currentPatrolIndex == patrolPoints.Length - 1)
                direction = -1;
            // If we've reached the first point, change direction to forward
            else if (currentPatrolIndex == 0)
                direction = 1;

            currentPatrolIndex += direction;
        }
    }
}

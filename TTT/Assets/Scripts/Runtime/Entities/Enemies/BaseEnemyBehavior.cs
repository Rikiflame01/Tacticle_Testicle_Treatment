using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemyBehavior
{
    protected EnemyController controller;
    protected Transform player;
    protected NavMeshAgent agent;
    protected PatrolBehavior patrolBehavior;

    public BaseEnemyBehavior(EnemyController controller)
    {
        this.controller = controller;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = controller.GetComponent<NavMeshAgent>();
        patrolBehavior = new PatrolBehavior(agent, controller.patrolPoints);
    }

    public abstract void HandleBehavior();
}

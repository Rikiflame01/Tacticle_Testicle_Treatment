using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
    [Header("Enemy Settings")]
    public float sightRange = 20f;
    public float chaseDuration = 5f;
    public Transform[] patrolPoints;
    public float patrolSpeed = 3.5f;
    public float chaseSpeed = 5.5f;

    private Transform eyeOrigin;
    private Transform playerTransform;
    private NavMeshAgent agent;
    public EnemyState CurrentState { get; private set; } = EnemyState.Walking;
    private float timeOutOfSight = 0f;
    private int currentPatrolIndex = 0;

    public enum EnemyState
    {
        Walking,
        Chasing,
        AttackingL,
        AttackingR,
        Walking1,
        Walking2
    }

    private void Awake()
    {
        eyeOrigin = transform.Find("Eye");
        agent = GetComponent<NavMeshAgent>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = patrolSpeed;
    }

    private void Update()
    {
        bool canSeePlayer = Sight.IsPlayerInSight(eyeOrigin, playerTransform, sightRange);

        if (canSeePlayer)
        {
            timeOutOfSight = 0f;
            ChangeState(EnemyState.Chasing);
        }
        else if (CurrentState == EnemyState.Chasing)
        {
            timeOutOfSight += Time.deltaTime;
            if (timeOutOfSight >= chaseDuration)
            {
                ChangeState(EnemyState.Walking);
            }
        }

        if (CurrentState == EnemyState.Chasing)
        {
            agent.SetDestination(playerTransform.position);
        }
        else
        {
            Patrol();
        }
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState = newState;
        agent.speed = (CurrentState == EnemyState.Chasing) ? chaseSpeed : patrolSpeed;

        if (CurrentState != EnemyState.Chasing && CurrentState != EnemyState.AttackingL && CurrentState != EnemyState.AttackingR)
        {
            CurrentState = EnemyState.Walking;  // Ensure Walking state when not chasing or attacking
        }
    }

    private void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }
}

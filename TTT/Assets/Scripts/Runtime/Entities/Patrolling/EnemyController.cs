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
    public float lookAtPlayerRange = 60f;
    public float attackDuration = 2f; // Duration of the attack state

    private Transform eyeOrigin;
    private Transform playerTransform;
    private NavMeshAgent agent;
    private float timeOutOfSight = 0f;
    private float attackTime = 0f; // Timer for attack duration
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

    public EnemyState CurrentState { get; private set; } = EnemyState.Walking;

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
            if (CurrentState != EnemyState.Chasing)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else if (CurrentState == EnemyState.Chasing)
        {
            timeOutOfSight += Time.deltaTime;
            if (timeOutOfSight >= chaseDuration)
            {
                ChangeState(EnemyState.Walking);
            }
        }

        if (CurrentState == EnemyState.AttackingL || CurrentState == EnemyState.AttackingR)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= attackDuration)
            {
                attackTime = 0f;
                ChangeState(canSeePlayer ? EnemyState.Chasing : EnemyState.Walking);
            }
        }

        if (CurrentState == EnemyState.Chasing)
        {
            agent.SetDestination(playerTransform.position);
        }
        else if (CurrentState == EnemyState.Walking)
        {
            Patrol();
            RotateTowardsPlayer();
        }
    }

    private void RotateTowardsPlayer()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) <= lookAtPlayerRange)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;
            directionToPlayer.y = 0; // Only rotate on the y-axis
            Quaternion rotationToPlayer = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotationToPlayer, Time.deltaTime * patrolSpeed);
        }
    }

    public void ChangeState(EnemyState newState)
    {
        CurrentState = newState;
        agent.speed = (CurrentState == EnemyState.Chasing) ? chaseSpeed : patrolSpeed;
        if (newState == EnemyState.AttackingL || newState == EnemyState.AttackingR)
        {
            attackTime = 0f; // Reset attack timer when entering an attack state
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

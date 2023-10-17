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
    public bool isChasing = false;
    private float timeOutOfSight = 0f;
    private int currentPatrolIndex = 0;

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
            timeOutOfSight = 0f; // Reset the timer if the player is in sight
            if (!isChasing)
            {
                StartChasing();
            }
        }
        else if (isChasing)
        {
            timeOutOfSight += Time.deltaTime;
            if (timeOutOfSight >= chaseDuration)
            {
                StopChasing();
            }
        }

        if (isChasing)
        {
            agent.SetDestination(playerTransform.position); // Continuously update the destination to the player's position
        }
        else
        {
            Patrol();
        }
    }

    private void StartChasing()
    {
        Debug.Log(gameObject.name + " started chasing the player.");
        agent.speed = chaseSpeed;
        isChasing = true;
    }

    private void StopChasing()
    {
        Debug.Log(gameObject.name + " stopped chasing and returned to patrol.");
        agent.speed = patrolSpeed;
        isChasing = false;
        Patrol();
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

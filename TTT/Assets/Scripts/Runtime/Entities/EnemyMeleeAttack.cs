using UnityEngine;

[RequireComponent(typeof(EnemyController))]
public class EnemyMeleeAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    public float attackRange = 1.5f;
    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    public float knockbackForce = 5f;

    private Transform player;
    private HealthComponent playerHealth;
    private Rigidbody playerRigidbody;
    private float timeSinceLastAttack = 0f;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = GetComponent<EnemyController>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject)
        {
            player = playerObject.transform;
            playerHealth = playerObject.GetComponent<HealthComponent>();
            playerRigidbody = playerObject.GetComponent<Rigidbody>();
        }
    }

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        if (enemyController.isChasing && CanAttackPlayer())
        {
            AttackPlayer();
            timeSinceLastAttack = 0f;
        }
    }

    private bool CanAttackPlayer()
    {
        if (player == null) return false;

        bool isInRange = Vector3.Distance(transform.position, player.position) <= attackRange;
        bool canAttack = timeSinceLastAttack >= attackCooldown;
        bool hasLineOfSight = !Physics.Linecast(transform.position, player.position, LayerMask.GetMask("Default")); // Assuming obstacles are in the "Default" layer.

        return isInRange && canAttack && hasLineOfSight;
    }

    private void AttackPlayer()
    {
        // Damage the player
        if (playerHealth)
        {
            playerHealth.TakeDamage(attackDamage);
        }

        // Apply knockback to the player
        if (playerRigidbody)
        {
            Vector3 knockbackDirection = (player.position - transform.position).normalized;
            playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);
        }
    }
}

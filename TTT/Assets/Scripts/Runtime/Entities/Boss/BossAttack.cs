using UnityEngine;
using static EnemyController;

[RequireComponent(typeof(EnemyController))]
public class BossAttack : MonoBehaviour
{
    [Header("Melee Attack Settings")]
    public float meleeAttackRange = 1.5f;
    public int meleeAttackDamage = 10;
    public float meleeAttackCooldown = 1.5f;
    public float meleeKnockbackForce = 5f;

    [Header("Ranged Attack Settings")]
    public GameObject projectilePrefab;
    public float rangedAttackRange = 10f;
    public int rangedAttackDamage = 20;
    public float rangedAttackCooldown = 20f;
    public Transform firePoint;

    private Transform player;
    private HealthComponent playerHealth;
    private Rigidbody playerRigidbody;
    private float timeSinceLastMeleeAttack = 0f;
    private float timeSinceLastRangedAttack = 0f;
    private EnemyController enemyController;
    private bool nextAttackIsLeft = true;

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
        timeSinceLastMeleeAttack += Time.deltaTime;
        timeSinceLastRangedAttack += Time.deltaTime;

        if (enemyController.CurrentState == EnemyState.Chasing)
        {
            if (CanAttackPlayer())
            {
                MeleeAttackPlayer();
                timeSinceLastMeleeAttack = 0f;
            }
            else if (CanPerformRangedAttack())
            {
                RangedAttackPlayer();
                timeSinceLastRangedAttack = 0f;
            }
        }
    }

    private bool CanAttackPlayer()
    {
        if (player == null) return false;

        bool isInRange = Vector3.Distance(transform.position, player.position) <= meleeAttackRange;
        bool canAttack = timeSinceLastMeleeAttack >= meleeAttackCooldown;
        bool hasLineOfSight = !Physics.Linecast(transform.position, player.position, LayerMask.GetMask("Default"));

        return isInRange && canAttack && hasLineOfSight;
    }

    private void MeleeAttackPlayer()
    {
        enemyController.ChangeState(nextAttackIsLeft ? EnemyState.AttackingL : EnemyState.AttackingR);
        nextAttackIsLeft = !nextAttackIsLeft;

        SFXManager.Instance.PlaySFX(SFXManager.Instance.playerDamageReceived);

        // Damage and knockback the player
        if (playerHealth)
        {
            playerHealth.TakeDamage(meleeAttackDamage);
        }

        if (playerRigidbody)
        {
            Vector3 knockbackDirection = (player.position - transform.position).normalized;
            playerRigidbody.AddForce(knockbackDirection * meleeKnockbackForce, ForceMode.Impulse);
        }
    }

    private bool CanPerformRangedAttack()
    {
        return player != null && Vector3.Distance(transform.position, player.position) <= rangedAttackRange && timeSinceLastRangedAttack >= rangedAttackCooldown;
    }

    private void RangedAttackPlayer()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("Projectile Prefab is not assigned in BossAttack script.");
            return;
        }

        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(player.position - firePoint.position));

        if (projectile == null)
        {
            Debug.LogError("Failed to instantiate projectile.");
            return;
        }

        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript == null)
        {
            Debug.LogError("Projectile prefab does not have a Projectile component attached.");
            return;
        }

        projectileScript.Initialize(rangedAttackDamage, player);
    }
}
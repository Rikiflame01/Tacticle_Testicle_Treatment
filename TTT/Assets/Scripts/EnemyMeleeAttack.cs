using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    public float attackRange = 1.5f; 
    public int attackDamage = 10;    
    public float attackCooldown = 1.5f; 
    public float knockbackForce = 5f; 

    private Transform player; 
    private HealthComponent playerHealth; // Reference to the player's HealthComponent
    private Rigidbody playerRigidbody; 
    private float timeSinceLastAttack = 0f; 

    private void Start()
    {
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

        if (player && Vector3.Distance(transform.position, player.position) <= attackRange && timeSinceLastAttack >= attackCooldown)
        {
            AttackPlayer();
            timeSinceLastAttack = 0f;
        }
    }

    void AttackPlayer()
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

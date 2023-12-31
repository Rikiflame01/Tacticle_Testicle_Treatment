using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed = 10f;
    private Transform target; // The primary target for the projectile
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity

        if (target != null && target.CompareTag("Player"))
        {
            Vector3 direction = (target.position - transform.position).normalized;
            rb.AddForce(direction * speed, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Target not set or not a player.");
        }
    }

    public void Initialize(int damage, Transform target)
    {
        this.damage = damage;
        this.target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the target (player)
        if (collision.gameObject == target.gameObject)
        {
            HandlePlayerCollision(collision.gameObject);
        }
        // Check if the collision is with a MeleeEnemy
        else if (collision.gameObject.CompareTag("MeleeEnemy"))
        {
            HandleMeleeEnemyCollision(collision);
        }

        // Destroy the projectile after collision
        Destroy(gameObject);
    }

    private void HandlePlayerCollision(GameObject player)
    {
        HealthComponent playerHealth = player.GetComponent<HealthComponent>();
        if (playerHealth)
        {
            playerHealth.TakeDamage(damage);
        }
        // Additional logic for player collision (if needed)
    }

    private void HandleMeleeEnemyCollision(Collision collision)
    {
        HealthComponent enemyHealth = collision.gameObject.GetComponent<HealthComponent>();
        if (enemyHealth)
        {
            enemyHealth.TakeDamage(damage);

            // Additional logic for melee enemy collision (if needed)
        }
    }
}

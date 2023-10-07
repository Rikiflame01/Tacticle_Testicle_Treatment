using UnityEngine;

public class ProjectileCollisionScript : MonoBehaviour
{
    public int damageAmount = 10; // Damage dealt by the projectile

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the projectile collided with an enemy
        HealthComponent enemyHealth = collision.gameObject.GetComponent<HealthComponent>();
        if (enemyHealth)
        {
            // Damage the enemy
            enemyHealth.TakeDamage(damageAmount);

            // Destroy the projectile after it hits the enemy
            Destroy(gameObject);
        }
    }
}

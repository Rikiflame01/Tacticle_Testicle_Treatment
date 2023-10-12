using UnityEngine;

public class ProjectileCollisionScript : MonoBehaviour
{
    public int damageAmount = 10; // Damage dealt by the projectile

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.bossDamage);
        }
        else
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.projectileCollision);
        }

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

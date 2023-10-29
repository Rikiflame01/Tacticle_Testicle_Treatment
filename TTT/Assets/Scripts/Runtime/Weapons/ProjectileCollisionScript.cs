using UnityEngine;

public class ProjectileCollisionScript : MonoBehaviour
{
    public int damageAmount = 10; // Damage dealt by the projectile

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.bossDamage, 3);
        }
        if (collision.gameObject.CompareTag("MeleeEnemy"))
        {

            SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
        }
        if (collision.gameObject.CompareTag("RangedEnemy"))
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
        }
        if (collision.gameObject.CompareTag("SpecialEnemy"))
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
        }
        else
        {

            SFXManager.Instance.PlaySFX(SFXManager.Instance.projectileCollision, 2);
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

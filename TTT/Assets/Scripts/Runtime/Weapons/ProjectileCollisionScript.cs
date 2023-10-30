using UnityEngine;

public class ProjectileCollisionScript : MonoBehaviour
{
    public int damageAmount = 10; // Damage dealt by the projectile

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            try
            {
                SFXManager.Instance.PlaySFX(SFXManager.Instance.bossDamage, 2);
            }
            catch (System.Exception e)
            {
                Debug.Log("Sound no work: " + e);
            }
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.bossDamage, 3);
        }
        if (collision.gameObject.CompareTag("MeleeEnemy"))
        {
            try
            {
                SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 2);
            }
            catch (System.Exception e)
            {
                Debug.Log("Sound no work: " + e);
            }
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
        }
        if (collision.gameObject.CompareTag("RangedEnemy"))
        {
            try
            {
                SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 2);
            }
            catch (System.Exception e)
            {
                Debug.Log("Sound no work: " + e);
            }
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
        }
        if (collision.gameObject.CompareTag("SpecialEnemy"))
        {
            try
            {
                SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 2);
            }
            catch (System.Exception e)
            {
                Debug.Log("Sound no work: " + e);
            }
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.enemyGrunt, 3);
        }
        else
        {
            try
            {
                SFXManager.Instance.PlaySFX(SFXManager.Instance.projectileCollision, 2);
            }
            catch (System.Exception e)
            {
                Debug.Log("Sound no work: " + e);
            }
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.projectileCollision, 2);
        }

        HealthComponent enemyHealth = collision.gameObject.GetComponent<HealthComponent>();
        if (enemyHealth)
        {
            // Damage the enemy
            enemyHealth.TakeDamage(damageAmount);

            // Destroy the projectile after it hits the enemy
            //Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
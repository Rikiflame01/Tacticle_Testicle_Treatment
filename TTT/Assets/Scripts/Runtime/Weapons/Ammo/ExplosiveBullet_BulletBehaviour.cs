using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    public class ExplosiveBullet_BulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        public float explosionRadius = 5f;
        public int ExplosionDamage = 25;
        public GameObject explosionEffect;
        public float BulletLifeTime = 5f;
        private float shootingForce = 800f;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive);
            Rigidbody bulletRb = this.GetComponent<Rigidbody>();

            Vector3 horizontalDirection = this.transform.forward.normalized;
            bulletRb.AddForce(horizontalDirection * shootingForce);

            Destroy(this, BulletLifeTime);
        }

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

            Explode();
        }

        #endregion UNITY METHODS

        #region METHODS

        public void OnDestroy()
        {
            Explode();
        }

        public void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider nearbyObject in colliders)
            {
                HealthComponent enemyHealth = nearbyObject.GetComponent<HealthComponent>();
                if (enemyHealth)
                {
                    // Damage the enemy
                    enemyHealth.TakeDamage(ExplosionDamage);
                }
            }
            // Instantiate the explosion effect
            Instantiate(explosionEffect, transform.position, transform.rotation);
            // Destroy the bullet
            Destroy(this);
        }

        #endregion METHODS
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    public class ExplosiveBullet_BulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        private Transform gunMuzzle;
        public float explosionRadius = 5f;
        public int ExplosionDamage = 25;
        public GameObject explosionEffect;
        public float BulletLifeTime = 5f;
        private float shootingForce = 800f;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            gunMuzzle = GameObject.FindGameObjectWithTag("GunMuzzle").transform;
            SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive, 1);
            Rigidbody bulletRb = this.GetComponent<Rigidbody>();

            Vector3 horizontalDirection = new Vector3(gunMuzzle.forward.x, 0, gunMuzzle.forward.z).normalized;
            bulletRb.AddForce(horizontalDirection * shootingForce * 10f);

            Destroy(this, BulletLifeTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            Explode();
            Destroy(this);
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
            //Destroy(this);
        }

        #endregion METHODS
    }
}
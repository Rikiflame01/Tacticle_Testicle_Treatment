using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    public class Rocket_BulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        private Transform gunMuzzle;
        public float explosionRadius = 5f;
        public int ExplosionDamage = 35;
        public GameObject explosionEffect;
        public float BulletLifeTime = 5f;
        private float BulletSpeed = 25f;
        private Rigidbody _bulletRb;
        private Vector3 horizontalDirection;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            gunMuzzle = GameObject.FindGameObjectWithTag("GunMuzzle").transform;
            SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingRocket);
            _bulletRb = this.GetComponent<Rigidbody>();

            horizontalDirection = new Vector3(gunMuzzle.forward.x, 0, gunMuzzle.forward.z).normalized;

            Destroy(this, BulletLifeTime);
        }

        private void FixedUpdate()
        {
            _bulletRb.AddRelativeForce(horizontalDirection * BulletSpeed);
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

        private void Explode()
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

        #endregion UNITY METHODS
    }
}
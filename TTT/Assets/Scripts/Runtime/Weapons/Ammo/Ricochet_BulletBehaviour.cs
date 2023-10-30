using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    public class Ricochet_BulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        private Rigidbody _bulletRb;
        private Transform gunMuzzle;
        public float damage = 10f;
        public float shootingForce = 1000f;
        public float BulletLifeTime = 5f;
        public int NumberOfBounces = 4;
        private Vector3 lastVel;
        private float currSpeed;
        private int currBounces = 0;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            _bulletRb = this.GetComponent<Rigidbody>();
            gunMuzzle = GameObject.FindGameObjectWithTag("GunMuzzle").transform;
            try
            {
                SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive, 2);
            }
            catch (System.Exception e)
            {
                Debug.Log("Sound no work: " + e);
            }
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive, 1);
            Vector3 horizontalDirection = new Vector3(gunMuzzle.forward.x, 0, gunMuzzle.forward.z).normalized;
            _bulletRb.AddForce(horizontalDirection * shootingForce * 10f);

            Destroy(this, BulletLifeTime);
        }

        private void LateUpdate()
        {
            lastVel = _bulletRb.velocity;

            /*if (_bulletRb.velocity.magnitude < 1f)
            {
                Destroy(this.gameObject);
            }*/
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (currBounces <= NumberOfBounces)
            {
                currSpeed = lastVel.magnitude;
                Vector3 reflect = Vector3.Reflect(_bulletRb.velocity.normalized, collision.contacts[0].normal);
                _bulletRb.AddForce(reflect * currSpeed);
                currBounces++;
                return;
            }
            else
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
                    enemyHealth.TakeDamage((int)damage);
                }
                Destroy(this.gameObject);
            }
        }

        #endregion UNITY METHODS
    }
}
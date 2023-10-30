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
            SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive, 1);
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
            if (currBounces >= NumberOfBounces)
                return;
            currSpeed = lastVel.magnitude;
            Vector3 reflect = Vector3.Reflect(_bulletRb.velocity.normalized, collision.contacts[0].normal);
            _bulletRb.AddForce(reflect * currSpeed);
            currBounces++;
        }

        #endregion UNITY METHODS
    }
}
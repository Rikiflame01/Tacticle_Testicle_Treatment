using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    public class StandardBulletBehaviour : MonoBehaviour
    {
        #region FIELDS

        public float shootingForce = 1000f;
        public float BulletLifeTime = 5f;
        private Transform gunMuzzle;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
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
            Rigidbody bulletRb = this.GetComponent<Rigidbody>();

            Vector3 horizontalDirection = new Vector3(gunMuzzle.forward.x, 0, gunMuzzle.forward.z).normalized;
            bulletRb.AddForce(horizontalDirection * shootingForce * 15f);

 //           Destroy(this, BulletLifeTime);
        }

        #endregion UNITY METHODS
    }
}
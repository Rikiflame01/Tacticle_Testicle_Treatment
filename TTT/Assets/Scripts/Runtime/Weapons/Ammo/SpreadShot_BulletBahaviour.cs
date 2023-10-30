using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    public class SpreadShot_BulletBahaviour : MonoBehaviour
    {
        #region FIELDS

        public float BulletLifeTime = 5f;
        public int NumberOfBullets = 5;
        public float spreadAngle = 30f;
        public float spreadAngleIncrement;
        private GameObject bulletPrefab;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive);
            SpawnChostCones();

            Destroy(this, BulletLifeTime);
        }

        #endregion UNITY METHODS

        #region METHODS

        private void SpawnChostCones()
        {
            float angle = -spreadAngle / 2;
            float angleIncrement = spreadAngle / NumberOfBullets;

            for (int i = 0; i < NumberOfBullets; i++)
            {
                float currentAngle = angle + (i * angleIncrement);
                Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
                GameObject bullet = Instantiate(bulletPrefab, this.transform.position, rotation);
            }
        }

        #endregion METHODS
    }
}
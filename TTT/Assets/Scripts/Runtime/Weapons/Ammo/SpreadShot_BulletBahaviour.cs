using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TTT
{
    public class SpreadShot_BulletBahaviour : MonoBehaviour
    {
        #region FIELDS

        public float BulletLifeTime = 2f;
        public int NumberOfBullets = 8;
        public float spreadAngle = 45f;
        public float spreadAngleIncrement;
        public GameObject bulletPrefab;

        #endregion FIELDS

        #region UNITY METHODS

        private void Awake()
        {
            //SFXManager.Instance.PlaySFX(SFXManager.Instance.shootingExplosive);
            SpawnCones();

            Destroy(this, BulletLifeTime);
        }

        #endregion UNITY METHODS

        #region METHODS

        private void SpawnCones()
        {
            float angle = -spreadAngle / 2;
            float angleIncrement = spreadAngle / NumberOfBullets;

            for (int i = 0; i < NumberOfBullets; i++)
            {
                float currentAngle = angle + (i * angleIncrement);
                //Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
                GameObject bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
                int random = Random.Range(0, 2);
                float randomAngle = Random.Range(0, spreadAngle);
                Quaternion rotation = Quaternion.Euler(0, 0, 0);
                switch (random)
                {
                    case 0:
                        rotation = Quaternion.Euler(randomAngle, currentAngle, 0);
                        break;

                    case 1:
                        rotation = Quaternion.Euler(currentAngle, randomAngle, 0);
                        break;

                    case 2:
                        rotation = Quaternion.Euler(currentAngle, currentAngle, 0);
                        break;
                }
                bullet.GetComponent<Rigidbody>().AddForce(rotation * bullet.transform.forward * 5000f);
            }
        }

        #endregion METHODS
    }
}
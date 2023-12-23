using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    [CreateAssetMenu(fileName = "BulletTypeSO", menuName = "ScriptableObjects/BulletTypeSO", order = 90)]
    public class BulletTypeSO : ScriptableObject
    {
        #region FIELDS

        public string bulletName;
        public GameObject bulletPrefab;
        public int maxAmmo;
        public int currentAmmo;

        public float cooldownTime; // Cooldown time in seconds
        private float lastFireTime; // Last time the bullet was fired


        #endregion FIELDS

        #region METHODS

        public void Initialize()
        {
            currentAmmo = maxAmmo;
        }

        public int getMaxAmmo() => maxAmmo;

        public int getCurrentAmmo() => currentAmmo;

        public void setCurrentAmmo(int ammo) => currentAmmo = ammo;

        public string getBulletName() => bulletName;

        public GameObject getBulletPrefab() => bulletPrefab;

        public bool CanFire()
        {
            return Time.time - lastFireTime >= cooldownTime;
        }

        public void fire()
        {
            if (currentAmmo > 0 && CanFire())
            {
                currentAmmo--;
                lastFireTime = Time.time; // Update last fire time
            }
        }

        #endregion METHODS
    }
}
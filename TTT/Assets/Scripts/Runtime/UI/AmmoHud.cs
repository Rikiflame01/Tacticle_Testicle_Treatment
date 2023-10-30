using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace TTT
{
    public class AmmoHud : MonoBehaviour
    {
        #region FIELDS

        private enum AmmoTypes
        {
            Standard,
            Rocket,
            Ricochet,
            Explosive,
            Laser,
            SpreadShot
        }

        public PlayerData PlayerData;
        public GameObject StandardAmmo;
        public GameObject Rocket;
        public GameObject Ricochet;
        public GameObject Explosive;
        public GameObject Laser;
        public GameObject SpreadShot;

        #endregion FIELDS

        #region UNITY METHODS

        private void Start()
        {
            updateAmmoHud();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                onAmmoBtnClicked();
            }
        }

        public void onAmmoBtnClicked()
        {
            PlayerData.IncrementBulletTypeIndex();
            updateAmmoHud();
        }

        public void updateAmmoHud()
        {
            switch (PlayerData.GetBulletName())
            {
                case "Standard":
                    SetAmmmoHud(AmmoTypes.Standard);
                    break;

                case "Rocket":
                    SetAmmmoHud(AmmoTypes.Rocket);
                    break;

                case "Ricochet":
                    SetAmmmoHud(AmmoTypes.Ricochet);
                    break;

                case "Explosive":
                    SetAmmmoHud(AmmoTypes.Explosive);
                    break;

                case "Laser":
                    SetAmmmoHud(AmmoTypes.Laser);
                    break;

                case "SpreadShot":
                    SetAmmmoHud(AmmoTypes.SpreadShot);
                    break;
            }
        }

        #endregion UNITY METHODS

        #region METHODS

        private void SetAmmmoHud(AmmoTypes ammo)
        {
            StandardAmmo.SetActive((int)ammo == 0);
            Rocket.SetActive((int)ammo == 1);
            Ricochet.SetActive((int)ammo == 2);
            Explosive.SetActive((int)ammo == 3);
            Laser.SetActive((int)ammo == 4);
            SpreadShot.SetActive((int)ammo == 5);
        }

        #endregion METHODS
    }
}
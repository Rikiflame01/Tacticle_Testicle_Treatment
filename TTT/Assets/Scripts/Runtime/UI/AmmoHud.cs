using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        private TextMeshProUGUI StandardAmmoCountText;
        public GameObject Rocket;
        private TextMeshProUGUI RocketAmmoCountText;
        public GameObject Ricochet;
        private TextMeshProUGUI RicochetAmmoCountText;
        public GameObject Explosive;
        private TextMeshProUGUI ExplosiveAmmoCountText;
        public GameObject Laser;
        private TextMeshProUGUI LaserAmmoCountText;
        public GameObject SpreadShot;
        private TextMeshProUGUI SpreadShotAmmoCountText;

        #endregion FIELDS

        #region UNITY METHODS

        private void Start()
        {
            updateAmmoHud();
            PlayerData.InitializeAmmoSO();
            StandardAmmoCountText = StandardAmmo.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            RocketAmmoCountText = Rocket.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            RicochetAmmoCountText = Ricochet.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            ExplosiveAmmoCountText = Explosive.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            LaserAmmoCountText = Laser.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            SpreadShotAmmoCountText = SpreadShot.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            UpdateAmmoCount();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                onAmmoBtnClicked();
            }
            UpdateAmmoCount();
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

        private void UpdateAmmoCount()
        {
            StandardAmmoCountText.text = PlayerData.GetCurrentAmmo().ToString();
            RocketAmmoCountText.text = PlayerData.GetCurrentAmmo().ToString();
            RicochetAmmoCountText.text = PlayerData.GetCurrentAmmo().ToString();
            ExplosiveAmmoCountText.text = PlayerData.GetCurrentAmmo().ToString();
            LaserAmmoCountText.text = PlayerData.GetCurrentAmmo().ToString();
            SpreadShotAmmoCountText.text = PlayerData.GetCurrentAmmo().ToString();
        }

        #endregion METHODS
    }
}
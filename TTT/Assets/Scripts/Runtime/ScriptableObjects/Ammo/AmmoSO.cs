using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TTT
{
    [CreateAssetMenu(fileName = "AmmoSO", menuName = "ScriptableObjects/AmmoSO", order = 90)]
    public class AmmoSO : ScriptableObject
    {
        #region FIELDS

        public BulletTypeSO[] AllBulletsTypes;
        public BulletTypeSO[] CurrentBulletTypes;
        public int currentBulletTypeIndex;

        #endregion FIELDS

        #region METHODS

        public void Initialize()
        {
            foreach (BulletTypeSO bulletType in CurrentBulletTypes)
            {
                if (bulletType)
                    bulletType.Initialize();
            }
        }

        public int getCurrentBulletTypeIndex() => currentBulletTypeIndex;

        public void incrementBulletTypeIndes()
        {
            if (currentBulletTypeIndex < CurrentBulletTypes.Length - 1)
            {
                currentBulletTypeIndex++;
            }
            else
            {
                currentBulletTypeIndex = 0;
            }
        }

        public int getCurrentAmmo() => CurrentBulletTypes[currentBulletTypeIndex].getCurrentAmmo();

        public int getMaxAmmo() => CurrentBulletTypes[currentBulletTypeIndex].getMaxAmmo();

        public void setCurrentAmmo(int ammo) => CurrentBulletTypes[currentBulletTypeIndex].setCurrentAmmo(ammo);

        public bool fire()
        {
            if (getCurrentAmmo() > 0)
            {
                CurrentBulletTypes[currentBulletTypeIndex].fire();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getBulletName() => CurrentBulletTypes[currentBulletTypeIndex].getBulletName();

        public GameObject getBulletPrefab() => CurrentBulletTypes[currentBulletTypeIndex].getBulletPrefab();

        public void resetAmmo()
        {
            foreach (BulletTypeSO bulletType in CurrentBulletTypes)
            {
                if (bulletType)
                    bulletType.setCurrentAmmo(bulletType.getMaxAmmo());
            }
        }

        public void resetBulletTypes()
        {
            BulletTypeSO[] AllTypesTmp = AllBulletsTypes;
            CurrentBulletTypes = new BulletTypeSO[1];
            AllBulletsTypes = AllTypesTmp;
            CurrentBulletTypes[0] = AllTypesTmp[0];
            Initialize();
        }

        public void AddRandomBulletType()
        {
            if (CurrentBulletTypes.Length == AllBulletsTypes.Length) { return; }
            BulletTypeSO newBulletType = AllBulletsTypes[Random.Range(0, AllBulletsTypes.Length)];
            while (System.Array.Exists(CurrentBulletTypes, element => element == newBulletType))
            {
                newBulletType = AllBulletsTypes[Random.Range(0, AllBulletsTypes.Length)];
            }
            BulletTypeSO[] tmp = new BulletTypeSO[CurrentBulletTypes.Length + 1];
            for (int i = 0; i < CurrentBulletTypes.Length; i++)
            {
                tmp[i] = CurrentBulletTypes[i];
            }
            newBulletType.Initialize();
            tmp[tmp.Length - 1] = newBulletType;
            CurrentBulletTypes = tmp;
        }

        public bool GetUniqueRandomBulletType(out BulletTypeSO bulletType)
        {
            if (CurrentBulletTypes.Length == AllBulletsTypes.Length)
            {
                bulletType = null;
                return false;
            }
            BulletTypeSO newBulletType = AllBulletsTypes[Random.Range(0, AllBulletsTypes.Length)];
            while (System.Array.Exists(CurrentBulletTypes, element => element == newBulletType))
            {
                newBulletType = AllBulletsTypes[Random.Range(0, AllBulletsTypes.Length)];
            }
            bulletType = newBulletType;
            return true;
        }

        public void AddBulletType(BulletTypeSO bulletType)
        {
            if (CurrentBulletTypes.Length == AllBulletsTypes.Length) { return; }
            BulletTypeSO[] tmp = new BulletTypeSO[CurrentBulletTypes.Length + 1];
            for (int i = 0; i < CurrentBulletTypes.Length; i++)
            {
                tmp[i] = CurrentBulletTypes[i];
            }
            bulletType.Initialize();
            tmp[tmp.Length - 1] = bulletType;
            CurrentBulletTypes = tmp;

            #endregion METHODS
        }
    }
}
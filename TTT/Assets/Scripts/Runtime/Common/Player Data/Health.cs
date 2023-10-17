using System;
using UnityEngine;

namespace Common.PlayerData
{
    [Serializable]
    public struct Health
    {
        #region FIELDS

        [Header("Health Settings")]
        public int maxHealth;

        public int currentHealth;
        public bool isDead;

        #endregion FIELDS

        #region METHODS

        public void Reset()
        {
            currentHealth = maxHealth;

            isDead = false;
        }

        public void TakeDamage(int damage)
        {
            if (isDead)
            {
                return;
            }

            currentHealth -= damage;
            if (currentHealth < 0)
            {
                currentHealth = 0;
            }
            isDead = currentHealth <= 0;
        }

        public void Heal(int heal)
        {
            if (isDead)
            {
                return;
            }

            currentHealth += heal;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        public int GetHealth() => currentHealth;

        public bool GetIsDead() => isDead;

        public void setMaxHealth(int max) => maxHealth = max;

        public void kill()
        {
            currentHealth = 0;
            isDead = true;
        }

        #endregion METHODS
    }
}
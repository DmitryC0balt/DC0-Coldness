using System;
using UnityEngine;

namespace Scripts.Health
{
    public class HealthMaster : IDamageable, IHealable
    {
        public readonly int maxHealth;
        public int currentHealth{ get; private set;}
        public bool isDead{ get; private set;}


        public event Action OnOutOfHealth;


        public HealthMaster(uint healthValue)
        {
            maxHealth = (int)healthValue;
            currentHealth = maxHealth;
        }


        public void ApplyDamage(int value)
        {
            ChangeHealth(value);
        }


        public void ApplyHealing(int value)
        {
            ChangeHealth(-value);
        }


        private void ChangeHealth(int value)
        {
            var newHealthValue = currentHealth + value;
            currentHealth = Mathf.Clamp(newHealthValue, 0, maxHealth);
        }

    }
}


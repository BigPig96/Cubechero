using System;
using Cubechero.Data;
using UnityEngine;

namespace Cubechero
{
    public sealed class Health
    {
        public event Action<float> OnHealthChanged;
        public event Action OnDie;
        public float MaxHealth => _healthData.maxHealth;
        public float CurrentHealth { get; private set; }

        private readonly HealthData _healthData;

        private Health(HealthData healthData)
        {
            _healthData = healthData;
        }

        public void ResetHealth()
        {
            ChangeHealth(MaxHealth);
        }

        public void TakeHeal(float heal)
        {
            ChangeHealth(CurrentHealth + heal);
        }
        
        public void TakeDamage(float damage)
        {
            ChangeHealth(CurrentHealth - damage);
            if (CurrentHealth <= 0) Die();
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
        
        private void ChangeHealth(float health)
        {
            CurrentHealth = Mathf.Clamp(health, 0, MaxHealth);
            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}
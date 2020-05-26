using System;
using Cubechero.Interfaces;
using UnityEngine;
using Zenject;

namespace Cubechero.Units
{
    public abstract class UnitBehaviour : MonoBehaviour, IDamagable, IPoolable<Vector3, Quaternion, IMemoryPool>, IDisposable
    {
        public Health Health { get; private set; }

        private IMemoryPool _pool;

        [Inject]
        private void InstallBindings(Health health)
        {
            Health = health;
        }

        protected virtual void Awake()
        {
        }

        public void TakeDamage(float damage)
        {
            Health.TakeDamage(damage);
        }

        private void ResetHealth()
        {
            Health.ResetHealth();
        }

        protected virtual void OnDie()
        {
            Dispose();
        }

        public virtual void OnDespawned()
        {
            _pool = null;
            Health.OnDie -= OnDie;
        }

        public virtual void OnSpawned(Vector3 position, Quaternion rotation, IMemoryPool pool)
        {
            _pool = pool;
            transform.SetPositionAndRotation(position, rotation);
            Health.OnDie += OnDie;
            ResetHealth();
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
    }
}

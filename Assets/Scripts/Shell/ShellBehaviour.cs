using System;
using Lib;
using UnityEngine;
using Zenject;

namespace Cubechero.Shell
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ShellBehaviour : MonoBehaviour, IPoolable<Vector3, Quaternion, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;
        
        [SerializeField] protected float lifetime;
        [SerializeField] protected float speed;

        protected Rigidbody RBody;
        
        private Wait _destruction;

        protected virtual void Awake()
        {
            RBody = GetComponent<Rigidbody>();
            _destruction = this.WaitForSeconds(lifetime, Destruct);
        }

        protected virtual void OnCollisionEnter(Collision other)
        {
            Destruct();
        }

        protected virtual void Destruct()
        {
            Dispose();
        }

        public virtual void OnDespawned()
        {
            _pool = null;
        }

        public virtual void OnSpawned(Vector3 position, Quaternion rotation, IMemoryPool pool)
        {
            _pool = pool;
            transform.SetPositionAndRotation(position, rotation);
            _destruction.Start();
        }

        public void Dispose()
        {
            _pool?.Despawn(this);
        }
    }
}

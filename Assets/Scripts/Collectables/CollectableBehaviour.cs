using System;
using UnityEngine;
using Zenject;

namespace Cubechero.Collectables
{
    public abstract class CollectableBehaviour : MonoBehaviour, IPoolable<Vector3, Quaternion, IMemoryPool>, IDisposable
    {
        [SerializeField] protected LayerMask collectMask;
        
        private IMemoryPool _pool;
        
        private void OnTriggerEnter(Collider other)
        {
            if((1 << other.gameObject.layer & collectMask) == 0) return;
            OnCollect();
        }

        protected abstract void OnCollect();

        public void OnDespawned()
        {
            _pool = null;
        }

        public void OnSpawned(Vector3 position, Quaternion rotation, IMemoryPool pool)
        {
            _pool = pool;
            transform.SetPositionAndRotation(position, rotation);
        }

        public void Dispose()
        {
            _pool.Despawn(this);
        }
    }
}
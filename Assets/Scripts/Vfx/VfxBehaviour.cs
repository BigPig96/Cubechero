using System;
using UnityEngine;
using Zenject;

namespace Cubechero.Vfx
{
    public abstract class VfxBehaviour : MonoBehaviour, IPoolable<Vector3, Quaternion, IMemoryPool>, IDisposable
    {
        private IMemoryPool _pool;

        public virtual void OnDespawned()
        {
            _pool = null;
        }

        public virtual void OnSpawned(Vector3 position, Quaternion rotation, IMemoryPool pool)
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

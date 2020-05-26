using UnityEngine;

namespace Cubechero.Spawners
{
    public abstract class SpawnerBehaviour
    {
        public virtual void Spawn(Vector3 position, Quaternion rotation)
        {
        }

        public virtual void Despawn()
        {
        }

        public virtual void DespawnAll()
        {
        }
    }
}
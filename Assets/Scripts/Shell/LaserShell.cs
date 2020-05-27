using Cubechero.Interfaces;
using UnityEngine;
using Zenject;

namespace Cubechero.Shell
{
    public sealed class LaserShell : ShellBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private LayerMask damageMask;

        public override void OnSpawned(Vector3 velocity, Vector3 position, Quaternion rotation, IMemoryPool pool)
        {
            base.OnSpawned(velocity, position, rotation, pool);

            RBody.velocity = velocity;
        }

        public override void OnDespawned()
        {
            base.OnDespawned();
            
            RBody.velocity = Vector3.zero;
        }

        protected override void OnCollisionEnter(Collision other)
        {
            var unit = other.gameObject.GetComponent<IDamagable>();
            if ((1 << other.gameObject.layer & damageMask) != 0)
                unit?.TakeDamage(damage);
            
            base.OnCollisionEnter(other);
        }

        public class Factory : PlaceholderFactory<Vector3, Vector3, Quaternion, LaserShell>
        {
        }
    }
}

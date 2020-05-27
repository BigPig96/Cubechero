using UnityEngine;
using Zenject;

namespace Cubechero.Shell
{
    public class BombShell : ShellBehaviour
    {
        private Explode _explode;

        [Inject]
        private void InstallBindings(Explode explode)
        {
            _explode = explode;
        }
        
        protected override void OnCollisionEnter(Collision other)
        {
            _explode.Execute(transform.position);
            
            base.OnCollisionEnter(other);
        }

        public override void OnSpawned(Vector3 velocity, Vector3 position, Quaternion rotation, IMemoryPool pool)
        {
            base.OnSpawned(velocity, position, rotation, pool);

            RBody.velocity = velocity;
        }

        public class Factory : PlaceholderFactory<Vector3, Vector3, Quaternion, BombShell>
        {
        }
    }
}
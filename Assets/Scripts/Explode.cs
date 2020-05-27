using System;
using Cubechero.Data;
using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero
{
    public sealed class Explode
    {
        private readonly float _damage;
        private readonly float _lesionRadius;
        private readonly Collider[] _targets;
        private readonly LayerMask _damageMask;

        public Explode(ExplosionData data)
        {
            _damage = data.damage;
            _lesionRadius = data.lesionRadius;
            _targets = new Collider[data.maxTargets];
            _damageMask = data.targetsMask;
        }

        public void Execute(Vector3 position)
        {
            Array.Clear(_targets, 0, _targets.Length);

            Physics.OverlapSphereNonAlloc(position, _lesionRadius, _targets, _damageMask);

            foreach (var hit in _targets)
            {
                if (hit == null) continue;
                IDamagable unit = hit.gameObject.GetComponent<IDamagable>();
                unit?.TakeDamage(_damage);
            }
        }
    }
}

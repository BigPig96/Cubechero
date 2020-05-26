using System;
using System.Collections.Generic;
using System.Linq;
using Cubechero.Data;
using Cubechero.Interfaces;
using Cubechero.Vfx;
using UnityEngine;
using Zenject;

namespace Cubechero
{
    public sealed class Explode
    {
        private readonly float _damage;
        private readonly float _lesionRadius;
        private readonly Collider2D[] _targets;
        private readonly LayerMask _damageMask;
        private readonly ExplosionEffect.Factory _factory;
        private readonly List<ExplosionEffect> _explosionEffects = new List<ExplosionEffect>();

        public Explode(ExplosionData data, ExplosionEffect.Factory factory)
        {
            _damage = data.damage;
            _lesionRadius = data.lesionRadius;
            _targets = new Collider2D[data.maxTargets];
            _damageMask = data.targetsMask;

            _factory = factory;
        }

        public void Execute(Vector3 position)
        {
            Array.Clear(_targets, 0, _targets.Length);

            Physics2D.OverlapCircleNonAlloc(position, _lesionRadius, _targets, _damageMask);

            foreach (var hit in _targets)
            {
                if (hit == null) continue;
                IDamagable unit = hit.gameObject.GetComponent<IDamagable>();
                unit?.TakeDamage(_damage);
            }
            
            AddEffect(position);
        }

        private void RemoveEffect()
        {
            if(!_explosionEffects.Any()) return;
            
            var effect = _explosionEffects[0];
            effect.Dispose();
            _explosionEffects.Remove(effect);
        }

        private void AddEffect(Vector3 position)
        {
            var effect = _factory.Create(position, Quaternion.identity);
            _explosionEffects.Add(effect);
        }
    }
}

using System;
using Cubechero.Data;
using UnityEngine;
using Zenject;

namespace Cubechero
{
    public sealed class UnitLocator : ITickable
    {
        private readonly Transform _transform;
        private readonly float _locateDelay;
        private readonly LayerMask _mask;
        private readonly Collider[] _targets;
        private readonly float _locatorRadius;

        private Collider _lastClosestCollider;
        private float _locateTimer;
        
        private UnitLocator(Transform transform, UnitLocatorData data)
        {
            _transform = transform;
            _locateDelay = data.locateDelay;
            _mask = data.mask;
            _targets = new Collider[data.maxTargets];
            _locatorRadius = data.locateRadius;
        }

        public Collider GetClosestCollider()
        {
            var originPos = _transform.position;
            if (_locateTimer < _locateDelay) return _lastClosestCollider;
            
            _locateTimer = 0;
            
            Physics.OverlapSphereNonAlloc(originPos, _locatorRadius, _targets, _mask);
            
            Collider target = null;
            var minDistance = Single.MaxValue;
            
            for (int i = 0; i < _targets.Length; i++)
            {
                if(_targets[i] == null) break;
                var distance = (_targets[i].transform.position - originPos).sqrMagnitude;
                if (distance < minDistance)
                {
                    minDistance = distance;
                    target = _targets[i];
                }
                
                _targets[i] = null;
            }

            _lastClosestCollider = target;

            return _lastClosestCollider;
        }

        public Vector3 GetClosestDirection()
        {
            return _lastClosestCollider != null
                ? (_lastClosestCollider.transform.position - _transform.position).normalized
                : Vector3.zero;
        }

        public void Tick()
        {
            _locateTimer += Time.deltaTime;
        }
    }
}
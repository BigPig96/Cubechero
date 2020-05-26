using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero.Inputs
{
    public sealed class PatrolEnemyMovementInput : IMovementInput
    {
        private readonly PatrolPoints _patrolPoints;
        private readonly Transform _transform;

        private Transform _currentTarget;

        private PatrolEnemyMovementInput(PatrolPoints patrolPoints, Transform transform)
        {
            _patrolPoints = patrolPoints;
            _transform = transform;
        }
        
        public Vector3 MoveDirection()
        {
            return _transform.forward;
        }

        public Vector3 LookDirection()
        {
            if (_currentTarget == null)
            {
                _currentTarget = _patrolPoints.GetRandomPoint();
                return Vector3.zero;
            }

            var offset = _currentTarget.position - _transform.position;
            var distance = offset.magnitude;
            if (distance > 1f) return offset.normalized;
            _currentTarget = _patrolPoints.GetRandomPoint();
            return Vector3.zero;
        }
    }
}
using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero.Inputs
{
    public class HeroWeaponInput : IWeaponInput
    {
        private readonly IMovementInput _movementInput;
        private readonly UnitLocator _locator;
        private readonly Transform _transform;

        private HeroWeaponInput(IMovementInput movementInput, UnitLocator locator, Transform transform)
        {
            _movementInput = movementInput;
            _locator = locator;
            _transform = transform;
        }
        
        public bool IsAttack()
        {
            if (_movementInput.MoveDirection() != Vector3.zero) return false;

            var closestTarget = _locator.GetClosestCollider();

            return closestTarget != null
                   && IsHeroLookToTarget();
        }

        public bool PreviousWeapon()
        {
            return Input.GetKeyDown(KeyCode.Q);
        }

        public bool NextWeapon()
        {
            return Input.GetKeyDown(KeyCode.E);
        }

        private bool IsHeroLookToTarget()
        {
            return Vector3.Dot(_transform.forward, _locator.GetClosestDirection()) > 0.99f;
        }
    }
}
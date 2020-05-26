using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero.Inputs
{
    public class HeroWeaponInput : IWeaponInput
    {
        private readonly IMovementInput _movementInput;
        private readonly UnitLocator _locator;
        private readonly Transform _transform;

        private Vector3 _lastClosestDirection;

        private HeroWeaponInput(IMovementInput movementInput, UnitLocator locator, Transform transform)
        {
            _movementInput = movementInput;
            _locator = locator;
            _transform = transform;
        }
        
        public bool IsAttack()
        {
            if (_movementInput.MoveDirection() != Vector3.zero) return false;

            _lastClosestDirection = _locator.GetClosestDirection();
            
            return _lastClosestDirection != Vector3.zero
                   && IsHeroLookToEnemy();
        }

        public bool PreviousWeapon()
        {
            return false;
        }

        public bool NextWeapon()
        {
            return false;
        }

        private bool IsHeroLookToEnemy()
        {
            return Vector3.Dot(_transform.forward, _lastClosestDirection) > 0.99f;
        }
    }
}
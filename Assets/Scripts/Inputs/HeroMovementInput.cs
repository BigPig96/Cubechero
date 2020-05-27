using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero.Inputs
{
    public class HeroMovementInput : IMovementInput
    {
        private readonly UnitLocator _locator;
        
        private HeroMovementInput(UnitLocator locator)
        {
            _locator = locator;
        }
        
        public Vector3 MoveDirection()
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }

        public Vector3 LookDirection()
        {
            var moveDirection = MoveDirection();
            if (moveDirection != Vector3.zero) return moveDirection;

            var closestTarget = _locator.GetClosestCollider();

            return closestTarget != null ? _locator.GetClosestDirection() : Vector3.zero;
        }
    }
}
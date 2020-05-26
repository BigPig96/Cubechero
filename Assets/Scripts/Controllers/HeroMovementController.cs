using Cubechero.Data;
using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero.Controllers
{
    public sealed class HeroMovementController : CommonMovementController, IMovementController
    {
        private HeroMovementController(IMovementInput movementInput, UnitMoveData moveData) 
            : base(movementInput, moveData)
        {
        }
        
        public void Control(Rigidbody input)
        {
            MoveProcess(input);
            RotateProcess(input.transform);
        }
    }
}
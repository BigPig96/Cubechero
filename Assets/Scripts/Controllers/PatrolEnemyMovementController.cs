using Cubechero.Data;
using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero.Controllers
{
    public sealed class PatrolEnemyMovementController : CommonMovementController, IMovementController
    {
        private PatrolEnemyMovementController(IMovementInput movementInput, UnitMoveData moveData) 
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
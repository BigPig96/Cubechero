using Cubechero.Data;
using Cubechero.Interfaces;
using UnityEngine;

namespace Cubechero.Controllers
{
    public abstract class CommonMovementController
    {
        protected readonly IMovementInput MovementInput;
        protected readonly UnitMoveData MoveData;

        protected CommonMovementController(IMovementInput movementInput, UnitMoveData moveData)
        {
            MovementInput = movementInput;
            MoveData = moveData;
        }

        protected virtual void MoveProcess(Rigidbody input)
        {
            Vector3 moveDirection = MovementInput.MoveDirection();
            Vector3 velocity = new Vector3(moveDirection.x * MoveData.moveSpeed, input.velocity.y,
                moveDirection.z * MoveData.moveSpeed);
            input.velocity = velocity;
        }

        protected virtual void RotateProcess(Transform input)
        {
            var rotateDirection = MovementInput.LookDirection();
            if(rotateDirection == Vector3.zero) return;
            
            var rotation = Quaternion.LookRotation(rotateDirection);
            input.transform.rotation = 
                Quaternion.Lerp(input.transform.rotation, rotation, MoveData.rotateSpeed * Time.deltaTime);
        }
    }
}
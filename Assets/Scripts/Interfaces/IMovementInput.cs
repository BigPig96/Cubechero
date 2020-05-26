using UnityEngine;

namespace Cubechero.Interfaces
{
    public interface IMovementInput
    {
        Vector3 MoveDirection();
        Vector3 LookDirection();
    }
}
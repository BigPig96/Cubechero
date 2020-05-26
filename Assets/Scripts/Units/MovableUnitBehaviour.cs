using Cubechero.Interfaces;
using UnityEngine;
using Zenject;

namespace Cubechero.Units
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class MovableUnitBehaviour : UnitBehaviour
    {
        private IMovementController _movementController;
        private Rigidbody _rb;

        protected override void Awake()
        {
            base.Awake();
            _rb = GetComponent<Rigidbody>();
        }

        [Inject]
        private void InstallBindings(IMovementController controller)
        {
            _movementController = controller;
        }

        protected virtual void Update()
        {
            MoveProcess();
        }

        private void MoveProcess()
        {
            _movementController.Control(_rb);
        }
    }
}

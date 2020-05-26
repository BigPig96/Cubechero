using Cubechero.Interfaces;
using UnityEngine;
using Zenject;

namespace Cubechero.Units
{
    public sealed class Hero : MovableUnitBehaviour
    {
        private IController _weaponController;

        [Inject]
        private void InstallBindings(IController weaponController)
        {
            _weaponController = weaponController;
        }

        protected override void Update()
        {
            base.Update();
            
            WeaponProcess();
        }

        private void WeaponProcess()
        {
            _weaponController.Control();
        }

        public class Factory : PlaceholderFactory<Vector3, Quaternion, Hero>
        {
        }
    }
}

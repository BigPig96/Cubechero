using Cubechero.Shell;
using UnityEngine;
using Zenject;

namespace Cubechero.Weapon
{
    public sealed class LaserGun : WeaponBehaviour
    {
        [SerializeField] private Transform point;
        [SerializeField] private float speed = 200;

        private LaserShell.Factory _factory;

        [Inject]
        private void InstallBindings(LaserShell.Factory factory, UnitLocator locator)
        {
            _factory = factory;
        }

        protected override void Launch()
        {
            AddShell();
        }

        private void AddShell()
        {
            _factory.Create(point.forward * speed, point.position, point.rotation);
        }
    }
}

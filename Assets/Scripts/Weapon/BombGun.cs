using Cubechero.Shell;
using UnityEngine;
using Zenject;

namespace Cubechero.Weapon
{
    public class BombGun : WeaponBehaviour
    {
        [SerializeField] private Transform point;

        private BombShell.Factory _factory;
        private UnitLocator _locator;

        [Inject]
        private void InstallBindings(BombShell.Factory factory, UnitLocator locator)
        {
            _factory = factory;
            _locator = locator;
        }

        protected override void Launch()
        {
            AddShell();
        }

        private void AddShell()
        {
            var target = _locator.GetClosestCollider().transform;
            if(target == null) return;
            var offset = target.position - point.position;
            var distance = offset.magnitude;
            var rad = Vector3.Angle(point.forward, offset.normalized) * Mathf.Deg2Rad;
            var speed = Ballistics.Speed(rad, distance);
            if(float.IsNaN(speed)) return;

            _factory.Create(point.forward * speed, point.position, point.rotation);
        }
    }
}
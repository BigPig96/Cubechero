using System.Collections.Generic;
using System.Linq;
using Cubechero.Shell;
using UnityEngine;
using Zenject;

namespace Cubechero.Weapon
{
    public sealed class LaserGun : WeaponBehaviour
    {
        [SerializeField] private Transform point;

        private LaserShell.Factory _factory;
        private readonly List<LaserShell> _shells = new List<LaserShell>();
        
        [Inject]
        private void InstallBindings(LaserShell.Factory factory)
        {
            _factory = factory;
        }

        protected override void Launch()
        {
            AddShell();
        }

        private void RemoveShell()
        {
            if(!_shells.Any()) return;
            
            var shell = _shells[0];
            shell.Dispose();
            _shells.Remove(shell);
        }

        private void AddShell()
        {
            var shell = _factory.Create(point.position, point.rotation);
            _shells.Add(shell);
        }
    }
}

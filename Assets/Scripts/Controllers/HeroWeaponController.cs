using System.Collections.Generic;
using Cubechero.Interfaces;
using Cubechero.Weapon;
using Zenject;

namespace Cubechero.Controllers
{
    public sealed class HeroWeaponController : IController, IInitializable
    {
        private readonly List<WeaponBehaviour> _weapons;
        private readonly IWeaponInput _weaponInput;

        private WeaponBehaviour _currentWeapon;
        private int _pointer;

        private HeroWeaponController(List<WeaponBehaviour> weapons, IWeaponInput weaponInput)
        {
            _weapons = weapons;
            _weaponInput = weaponInput;
        }

        public void Control()
        {
            if(_weaponInput.IsAttack()) _currentWeapon.Fire();
            if (_weaponInput.PreviousWeapon()) ChangeWeapon(-1);
            if (_weaponInput.NextWeapon()) ChangeWeapon(1);
        }

        public void Initialize()
        {
            foreach (var weapon in _weapons)
            {
                weapon.Initialize();
            }
            
            _currentWeapon = _weapons[_pointer];
            _currentWeapon.Activate();
        }

        private void ChangeWeapon(int changeIndex)
        {
            _pointer += changeIndex;
            if (_pointer < 0) _pointer = _weapons.Count - _pointer;
            if (_pointer >= _weapons.Count) _pointer -= _weapons.Count;

            _currentWeapon.Deactivate();
            _currentWeapon = _weapons[_pointer];
            _currentWeapon.Activate();
        }
    }
}
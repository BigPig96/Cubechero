using System.Collections.Generic;
using Cubechero.Controllers;
using Cubechero.Inputs;
using Cubechero.Weapon;
using UnityEngine;
using Zenject;

namespace Cubechero.Installs
{
    public class HeroWeaponInstaller : MonoInstaller
    {
        [SerializeField] private List<WeaponBehaviour> weapons;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HeroWeaponController>().AsSingle().WithArguments(weapons);
            Container.BindInterfacesAndSelfTo<HeroWeaponInput>().AsSingle();
        }
    }
}
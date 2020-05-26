using Cubechero.Controllers;
using Cubechero.Data;
using Cubechero.Inputs;
using UnityEngine;

namespace Cubechero.Installs
{
    public class HeroMovementInstaller : MovementInstaller<HeroMovementController, HeroMovementInput>
    {
        [SerializeField] private UnitLocatorData locatorData;
        
        public override void InstallBindings()
        {
            base.InstallBindings();
            
            Container.BindInterfacesAndSelfTo<UnitLocator>().AsSingle().WithArguments(locatorData);
        }
    }
}
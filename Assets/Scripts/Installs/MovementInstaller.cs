using Cubechero.Data;
using Cubechero.Interfaces;
using UnityEngine;
using Zenject;

namespace Cubechero.Installs
{
    public abstract class MovementInstaller<TController, TInput> : MonoInstaller
        where TController : IMovementController where TInput : IMovementInput
    {
        [SerializeField] protected UnitMoveData moveData;
        
        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromComponentsOn(gameObject).AsSingle();
            Container.BindInterfacesAndSelfTo<TController>()
                .AsSingle()
                .WithArguments(moveData);
            Container.BindInterfacesAndSelfTo<TInput>()
                .AsSingle();
        }
    }
}
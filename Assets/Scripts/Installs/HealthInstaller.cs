using Cubechero.Data;
using UnityEngine;
using Zenject;

namespace Cubechero.Installs
{
    public class HealthInstaller : MonoInstaller
    {
        [SerializeField] private HealthData healthData;
        
        public override void InstallBindings()
        {
            Container.Bind<Health>().AsSingle().WithArguments(healthData);
        }
    }
}
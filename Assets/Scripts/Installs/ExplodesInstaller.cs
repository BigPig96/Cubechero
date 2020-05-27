using Cubechero.Data;
using Cubechero.Shell;
using UnityEngine;
using Zenject;

namespace Cubechero.Installs
{
    public class ExplodesInstaller : MonoInstaller
    {
        [SerializeField] private ExplosionData bombShellsExplosionData;
        
        public override void InstallBindings()
        {
            Container.Bind<Explode>().AsCached().WithArguments(bombShellsExplosionData).WhenInjectedInto<BombShell>();
        }
    }
}
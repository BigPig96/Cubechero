using Zenject;

namespace Cubechero.Installs
{
    public class SceneEnvironmentsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PatrolPoints>().FromComponentInHierarchy().AsSingle();
        }
    }
}
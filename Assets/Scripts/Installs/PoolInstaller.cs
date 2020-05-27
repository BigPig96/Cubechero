using Cubechero.Collectables;
using Cubechero.Shell;
using Cubechero.Units;
using UnityEngine;
using Zenject;

namespace Cubechero.Installs
{
    public class PoolInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindFactory<Vector3, Vector3, Quaternion, LaserShell, LaserShell.Factory>()
                .FromMonoPoolableMemoryPool(
                    x => x.WithInitialSize(10)
                        .FromComponentInNewPrefabResource("Shells/LaserShell")
                        .UnderTransformGroup("LaserShells"));
            Container.BindFactory<Vector3, Vector3, Quaternion, BombShell, BombShell.Factory>()
                .FromMonoPoolableMemoryPool(
                    x => x.WithInitialSize(10)
                        .FromComponentInNewPrefabResource("Shells/BombShell")
                        .UnderTransformGroup("BombShells"));
            Container.BindFactory<Vector3, Quaternion, PatrolEnemy, PatrolEnemy.Factory>()
                .FromMonoPoolableMemoryPool(
                    x => x.WithInitialSize(10)
                        .FromComponentInNewPrefabResource("Units/PatrolEnemy")
                        .UnderTransformGroup("PatrolEnemies"));
            Container.BindFactory<Vector3, Quaternion, Hero, Hero.Factory>()
                .FromMonoPoolableMemoryPool(
                    x => x.WithInitialSize(1)
                        .FromComponentInNewPrefabResource("Units/Hero"));
            Container.BindFactory<Vector3, Quaternion, Coin, Coin.Factory>()
                .FromMonoPoolableMemoryPool(
                    x => x.WithInitialSize(20)
                        .FromComponentInNewPrefabResource("Collectables/Coin")
                        .UnderTransformGroup("Coins"));
        }
    }
}
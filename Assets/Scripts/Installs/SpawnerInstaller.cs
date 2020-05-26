using Cubechero.Spawners;
using UnityEngine;
using Zenject;

namespace Cubechero.Installs
{
    public class SpawnerInstaller : MonoInstaller
    {
        [SerializeField] private int patrolEnemiesCount;
        [SerializeField] private Transform heroSpawnPoint;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PatrolEnemySpawner>().AsSingle().WithArguments(patrolEnemiesCount);
            Container.BindInterfacesAndSelfTo<HeroSpawner>().AsSingle().WithArguments(heroSpawnPoint);
        }
    }
}
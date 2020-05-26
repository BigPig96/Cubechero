using Cubechero.Units;
using UnityEngine;
using Zenject;

namespace Cubechero.Spawners
{
    public sealed class HeroSpawner : SpawnerBehaviour, IInitializable
    {
        public Hero Hero { get; private set; }

        private readonly Hero.Factory _factory;
        private readonly Transform _heroSpawnPoint;

        private HeroSpawner(Hero.Factory factory, Transform heroSpawnPoint)
        {
            _factory = factory;
            _heroSpawnPoint = heroSpawnPoint;
        }

        public void Initialize()
        {
            Spawn(_heroSpawnPoint.position, _heroSpawnPoint.rotation);
        }

        public override void Spawn(Vector3 position, Quaternion rotation)
        {
            Hero = _factory.Create(position, rotation);
        }
    }
}
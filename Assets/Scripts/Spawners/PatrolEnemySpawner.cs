using System;
using System.Collections.Generic;
using System.Linq;
using Cubechero.Units;
using UnityEngine;
using Zenject;

namespace Cubechero.Spawners
{
    public sealed class PatrolEnemySpawner : SpawnerBehaviour, IInitializable, IDisposable
    {
        private readonly int _enemiesCount;
        private readonly PatrolEnemy.Factory _factory;
        private readonly List<PatrolEnemy> _enemies = new List<PatrolEnemy>();
        private readonly PatrolPoints _patrolPoints;

        private PatrolEnemySpawner(int enemiesCount, PatrolEnemy.Factory factory, PatrolPoints patrolPoints)
        {
            _enemiesCount = enemiesCount;
            _factory = factory;
            _patrolPoints = patrolPoints;
        }

        public void Initialize()
        {
            EnemyBehaviour.OnEnemyDie += OnEnemyDie;

            for (int i = 0; i < _enemiesCount; i++)
            {
                var randomPoint = _patrolPoints.GetRandomPoint();
                Spawn(randomPoint.position, randomPoint.rotation);
            }
        }

        public void Dispose()
        {
            EnemyBehaviour.OnEnemyDie -= OnEnemyDie;
        }
        
        private void OnEnemyDie(object sender, EnemyBehaviour.DieArgs e)
        {
            if(!(e.Enemy is PatrolEnemy)) return;
            
            var randomPoint = _patrolPoints.GetRandomPoint();
            Spawn(randomPoint.position, randomPoint.rotation);
        }

        public override void Despawn()
        {
            if(!_enemies.Any()) return;
            
            var enemy = _enemies[0];
            enemy.Dispose();
            _enemies.Remove(enemy);
        }

        public override void Spawn(Vector3 position, Quaternion rotation)
        {
            var enemy = _factory.Create(position, rotation);
            _enemies.Add(enemy);
        }
    }
}
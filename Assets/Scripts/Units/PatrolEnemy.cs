using Cubechero.Collectables;
using UnityEngine;
using Zenject;

namespace Cubechero.Units
{
    public class PatrolEnemy : EnemyBehaviour
    {
        private Coin.Factory _factory;

        [Inject]
        private void InstallBindings(Coin.Factory factory)
        {
            _factory = factory;
        }

        protected override void OnDie()
        {
            var beforeDiePosition = transform.position;
            
            base.OnDie();

            _factory.Create(beforeDiePosition, Quaternion.identity);
        }

        public class Factory : PlaceholderFactory<Vector3, Quaternion, PatrolEnemy>
        {
        }
    }
}
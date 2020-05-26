using System;

namespace Cubechero.Units
{
    public class EnemyBehaviour : MovableUnitBehaviour
    {
        public static event EventHandler<DieArgs> OnEnemyDie;

        public class DieArgs : EventArgs
        {
            public readonly EnemyBehaviour Enemy;

            public DieArgs(EnemyBehaviour enemy)
            {
                Enemy = enemy;
            }
        }
        
        protected override void OnDie()
        {
            base.OnDie();
            
            OnEnemyDie?.Invoke(this, new DieArgs(this));
        }
    }
}
using Cubechero.Units;
using DG.Tweening;
using UnityEngine;

namespace Cubechero
{
    public sealed class CameraShakerEnemyDieEvent : MonoBehaviour
    {
        [SerializeField] private float shakeDuration;
        
        private void OnEnable()
        {
            EnemyBehaviour.OnEnemyDie += OnEnemyDie;
        }

        private void OnDisable()
        {
            EnemyBehaviour.OnEnemyDie -= OnEnemyDie;
        }

        private void OnEnemyDie(object sender, EnemyBehaviour.DieArgs e)
        {
            Shake();
        }

        private void Shake()
        {
            transform.DOShakePosition(shakeDuration);
        }
    }
}
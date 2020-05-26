using UnityEngine;
using Zenject;

namespace Cubechero.Collectables
{
    public class Coin : CollectableBehaviour
    {
        protected override void OnCollect()
        {
            Dispose();
        }

        public class Factory : PlaceholderFactory<Vector3, Quaternion, Coin>
        {
        }
    }
}
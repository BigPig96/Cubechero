using UnityEngine;

namespace Cubechero.Data
{
    [CreateAssetMenu]
    public sealed class ExplosionData : ScriptableObject
    {
        public float damage;
        public float lesionRadius;
        public int maxTargets;
        public LayerMask targetsMask;
    }
}

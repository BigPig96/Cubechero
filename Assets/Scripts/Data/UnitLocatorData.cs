using UnityEngine;

namespace Cubechero.Data
{
    [CreateAssetMenu]
    public class UnitLocatorData : ScriptableObject
    {
        public LayerMask mask;
        public float locateDelay;
        public int maxTargets;
        public float locateRadius;
    }
}
using UnityEngine;
using Zenject;

namespace Cubechero.Vfx
{
    public sealed class ExplosionEffect : VfxBehaviour
    {
        public class Factory : PlaceholderFactory<Vector3, Quaternion, ExplosionEffect>
        {
        }
    }
}

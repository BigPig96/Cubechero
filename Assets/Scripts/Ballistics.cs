using UnityEngine;

namespace Cubechero
{
    public static class Ballistics
    {
        public static float Speed(float rad, float s)
        {
            return Mathf.Sqrt(s * 9.81f / (2 * Mathf.Sin(rad) * Mathf.Cos(rad)));
        }
    }
}
using UnityEngine;

namespace Cubechero
{
    public class PatrolPoints : MonoBehaviour
    {
        [SerializeField] private Transform[] points;

        public Transform GetRandomPoint()
        {
            int randomIndex = Random.Range(0, points.Length);
            return points[randomIndex];
        }
    }
}
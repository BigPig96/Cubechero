using Cubechero.Spawners;
using UnityEngine;
using Zenject;

namespace Cubechero
{
    public sealed class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed;
        [SerializeField] private Vector3 offset;

        private HeroSpawner _heroSpawner;

        [Inject]
        private void InstallBindings(HeroSpawner heroSpawner)
        {
            _heroSpawner = heroSpawner;
        }

        private void FixedUpdate()
        {
            if (target == null)
            {
                target = _heroSpawner.Hero.transform;
                return;
            }
            
            var cameraPosition = transform.position;
            var targetPos = new Vector3(cameraPosition.x, cameraPosition.y, target.position.z) + offset;
            transform.position = Vector3.Lerp(cameraPosition, targetPos, speed * Time.fixedTime);
        }
    }
}

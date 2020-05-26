using UnityEngine;

namespace Cubechero
{
    public sealed class FromWorldToScreenFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector2 offset;

        private Vector2 _lastScreenPos;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void FixedUpdate()
        {
            var screenPos = (Vector2) _camera.WorldToScreenPoint(target.position);
            if(screenPos == _lastScreenPos) return;

            _lastScreenPos = screenPos;
            transform.position = screenPos + offset;
        }
    }
}
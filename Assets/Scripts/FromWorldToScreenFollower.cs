using UnityEngine;

namespace Cubechero
{
    public sealed class FromWorldToScreenFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector2 offset;

        private Vector2 _lastScreenPos;

        private Camera _camera;
        private Vector2 _screenSize;
        private Vector2 _offset;

        private void Awake()
        {
            _camera = Camera.main;
            _screenSize = new Vector2(Screen.width, Screen.height);
            _offset = new Vector2(_screenSize.x * offset.x, _screenSize.y * offset.y);
        }

        private void FixedUpdate()
        {
            var screenPos = (Vector2) _camera.WorldToScreenPoint(target.position);
            if(screenPos == _lastScreenPos) return;

            _lastScreenPos = screenPos;
            transform.position = screenPos + _offset;
        }
    }
}
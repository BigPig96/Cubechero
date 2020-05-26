using Cubechero.Units;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Cubechero
{
    public sealed class HealthBar : MonoBehaviour
    {
        private enum VisionMode
        {
            Always,
            AutoHide
        }

        [SerializeField] private VisionMode visionMode = VisionMode.Always;
        [SerializeField] private UnitBehaviour unit;
        [SerializeField] private Image background;
        [SerializeField] private Image mainHealthIndicator;
        [SerializeField] private Image secondHealthIndicator;
        [SerializeField] private float changeTime = 0.2f;
        [SerializeField] private float delayBetweenIndicators = 0.2f;
        
        private float _maxHealth;

        private void Awake()
        {
            _maxHealth = unit.Health.MaxHealth;
        }

        private void OnEnable()
        {
            OnChangeHealth(unit.Health.CurrentHealth);
            unit.Health.OnHealthChanged += OnChangeHealth;
        }

        private void OnDisable()
        {
            unit.Health.OnHealthChanged -= OnChangeHealth;
        }

        private void Start()
        {
            Hide(visionMode == VisionMode.AutoHide);
        }

        private void OnChangeHealth(float newHealth)
        {
            float fill = newHealth / _maxHealth;
            Hide((visionMode == VisionMode.AutoHide && !(fill < 1f)) || newHealth <= 0);
            UpdateBar(fill);
        }

        private void Hide(bool hide)
        {
            background.enabled = !hide;
            mainHealthIndicator.enabled = !hide;
            secondHealthIndicator.enabled = !hide;
        }

        private void UpdateBar(float fill)
        {
            mainHealthIndicator.DOFillAmount(fill, changeTime);
            secondHealthIndicator.DOFillAmount(fill, changeTime).SetDelay(delayBetweenIndicators);
        }
    }
}

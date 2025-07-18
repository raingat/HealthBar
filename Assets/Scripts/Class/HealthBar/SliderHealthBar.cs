using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= ChangeValue;
    }

    private void ChangeValue(float currentHealth)
    {
        _slider.value = currentHealth / _health.MaxHealth;
    }
}

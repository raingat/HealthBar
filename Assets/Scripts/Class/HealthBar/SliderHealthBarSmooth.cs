using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBarSmooth : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private float _stepHealth;

    private Slider _slider;

    private Coroutine _coroutine;

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
        float fractionMaximumHealth = currentHealth / _health.MaxHealth;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }

        _coroutine = StartCoroutine(ChangeState(fractionMaximumHealth));
    }

    private IEnumerator ChangeState(float fractionMaximumHealth)
    {
        while (_slider.value != fractionMaximumHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, fractionMaximumHealth, _stepHealth * Time.deltaTime);

            yield return null;
        }
    }
}

using System.Collections;
using UnityEngine;

public class SliderHealthBarSmooth : SliderHealthBar
{
    private Coroutine _coroutine;

    private float _stepIncreaseCoefficient = 1.0f;

    protected override void ChangeValue(float currentHealth)
    {
        float fractionMaximumHealth = currentHealth / _health.MaxHealth;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }

        float startPosition = _slider.value;

        _coroutine = StartCoroutine(ChangeState(fractionMaximumHealth, startPosition));
    }

    private IEnumerator ChangeState(float fractionMaximumHealth, float startPosition)
    {
        float step = 0.0f;

        while (_slider.value != fractionMaximumHealth)
        {
            step = Mathf.Clamp01(step += _stepIncreaseCoefficient * Time.deltaTime);

            _slider.value = Mathf.Lerp(startPosition, fractionMaximumHealth, step);

            yield return null;
        }
    }
}

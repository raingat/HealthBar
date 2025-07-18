using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected void OnEnable()
    {
        _health.HealthChanged += ChangeValue;
    }

    protected void OnDisable()
    {
        _health.HealthChanged -= ChangeValue;
    }

    protected abstract void ChangeValue(float currentHealth);
}

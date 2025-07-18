using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamagable
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _minHealth;

    private float _currentHealth;

    public event Action<GameObject> Died;
    public event Action<float> HealthChanged;

    public float MaxHealth => _maxHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= _minHealth)
            _currentHealth = _minHealth;

        if (IsDied())
            Died?.Invoke(gameObject);

        HealthChanged?.Invoke(_currentHealth);
    }

    public void Treat(float countHeal)
    {
        _currentHealth += countHeal;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth);
    }

    private bool IsDied()
    {
        return _currentHealth <= _minHealth;
    }
}

using TMPro;
using UnityEngine;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    [SerializeField] private TMP_Text _text;

    private string _maxHealth;

    private void Awake()
    {
        _maxHealth = _health.MaxHealth.ToString();

        _text.text = $"{_maxHealth}/{_maxHealth}";
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
        _text.text = $"{currentHealth}/{_maxHealth}";
    }
}

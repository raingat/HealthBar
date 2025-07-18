using TMPro;
using UnityEngine;

public class TextHealthBar : HealthBar
{
    [SerializeField] private TMP_Text _text;

    private string _maxHealth;

    private void Awake()
    {
        _maxHealth = _health.MaxHealth.ToString();

        _text.text = $"{_maxHealth}/{_maxHealth}";
    }

    protected override void ChangeValue(float currentHealth)
    {
        _text.text = $"{currentHealth}/{_maxHealth}";
    }
}

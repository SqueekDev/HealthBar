using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _maxValue = 100;
    private float _minValue = 0;
    private float _changeValue = 10;
    private float _currentValue;

    public float MaxValue { get => _maxValue; }
    public float CurrentValue { get => _currentValue; }
    public event UnityAction<float> ValueChanged;

    private void Awake()
    {
        _currentValue = _maxValue;
    }

    private void OnEnable()
    {
        _player.HealthChanged += ChangeHealthValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeHealthValue;        
    }

    private void ChangeHealthValue(bool isDamaged)
    {
        if (isDamaged && _currentValue > _minValue)
            _currentValue -= _changeValue;
        else if (isDamaged == false && _currentValue < _maxValue)
            _currentValue += _changeValue;

        ValueChanged?.Invoke(_currentValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private Coroutine _healthBarChange;

    private void Start()
    {
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.CurrentValue;
    }

    private void OnEnable()
    {
        _health.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= OnValueChanged;        
    }

    private void OnValueChanged(float currentValue)
    {
        if (_healthBarChange != null)
        {
            StopCoroutine(_healthBarChange);
        }

        _healthBarChange = StartCoroutine(ChangeHealthBarValue(currentValue));
    }

    private IEnumerator ChangeHealthBarValue(float target)
    {
        float changeDelay = 0.03f;
        WaitForSeconds delay = new WaitForSeconds(changeDelay);

        while (_slider.value != target)
        {
            float changeStep = 1f;
            _slider.value = Mathf.MoveTowards(_slider.value, target, changeStep);
            yield return delay;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<bool> HealthChanged;

    public void ChangeHealthValue(bool isDamaged)
    {
        HealthChanged?.Invoke(isDamaged);
    }
}

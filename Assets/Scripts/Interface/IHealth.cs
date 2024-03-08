using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
    public void TakeDamage(float _Damage)
    { }
    public void Heal(float _HealthAmount)
    { }

    public float GetHealth()
    {
        return 0;
    }
}

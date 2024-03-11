using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public void TakeDamage(int damage);
    public void Heal(int healthAmount);
    public void Die();
    public int GetHealth();
}

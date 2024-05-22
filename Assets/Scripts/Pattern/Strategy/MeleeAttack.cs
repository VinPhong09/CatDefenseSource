using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttack : IAttack
{
    public void Attack(IHealth targetHealth, int damage)
    {
        targetHealth.TakeDamage(damage);
    }
}

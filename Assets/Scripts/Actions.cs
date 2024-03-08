using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public event Action<float> OnTakeDamage;
    public event Action<float> OnHeal;
    public event Func<int> GetHP;
}

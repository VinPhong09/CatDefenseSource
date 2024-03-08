using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEvent: MonoBehaviour, IHealth
{
   public event Action<int> OnAttack;
   public event Action<int> OnTakeDamage;
   public event Action<int> OnHeal; 

   public void TakeDamage(int damage)
   {
      Debug.Log("Damage: " + damage);
      OnTakeDamage?.Invoke(damage);
   }

   public void Heal(int healAmount)
   {
      OnHeal?.Invoke(healAmount);
   }

   public float GetHealth()
   {
      throw new NotImplementedException();
   }
}

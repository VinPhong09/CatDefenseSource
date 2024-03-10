using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class CharacterEvent: MonoBehaviour, IHealth, IEvent
{
   public event Action OnAttack;
   public event Action<int> OnTakeDamage;
   public event Action<int> OnHeal;
   
   public void TakeDamage(int damage)
   {
      OnTakeDamage?.Invoke(damage);
   }

   public void Heal(int healAmount)
   {
      OnHeal?.Invoke(healAmount);
   }

   public void Attack()
   {
      OnAttack?.Invoke();
   }
   
   
   public float GetHealth()
   {
      throw new NotImplementedException();
   }
}

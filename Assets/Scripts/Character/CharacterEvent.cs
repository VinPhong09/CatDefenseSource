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
   public event Action OnKill;
   public event Action OnDie;

   public event Func<int> OnGetHealth; 
   public void TakeDamage(int damage)
   {
      OnTakeDamage?.Invoke(damage);
   }

   public void Heal(int healAmount)
   {
      OnHeal?.Invoke(healAmount);
   }

   public void Die()
   {
      OnDie?.Invoke();
   }

   public void Attack()
   {
      OnAttack?.Invoke();
   }
   
   
   public int GetHealth()
   {
      return OnGetHealth.Invoke();
   }
}

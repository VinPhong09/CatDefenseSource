using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class CharacterController : IController
{
    private CharacterModel _characterModel;
    private CharacterView _characterView;

    private CharacterEvent _characterEvent;
    /*public event Action<int> OnTakeDamage;
    public event Action<int> OnHeal;
    public event Func<int> GetHP;*/
    
    
    public CharacterController(CharacterModel characterModel, CharacterView characterView, CharacterEvent characterEvent)
    {
        this._characterModel = characterModel;
        this._characterView = characterView;
        this._characterEvent = characterEvent;
    }

    public void Initialize()
    {
        _characterView.Initialize();
        EventRegister();
    }

    public void Handle()
    {
        _characterView.OnUpdate();
      
    }

    public void EventRegister()
    {
        _characterEvent.OnTakeDamage += TakeDamage;
        _characterEvent.OnHeal += Heal;
    }

    public void EventUnRegister()
    {
        _characterEvent.OnTakeDamage -= TakeDamage;
        _characterEvent.OnHeal -= Heal;
    }


    public void Move()
    {
        throw new NotImplementedException();
    }

    public virtual void Attack()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _characterModel.CurrentHealth -= damage;
        Debug.Log("CurH" + _characterModel.CurrentHealth);
        _characterView.ShowDamagePopUp(damage);
        _characterView.OnHealthChange(_characterModel.CurrentHealth);
        if (_characterModel.CurrentHealth <= 0)
        {
            _characterView.OnAnimation(AnimationState.Die);
        }
    }
    
    public void Heal(int healthAmount)
    {
        _characterModel.CurrentHealth += healthAmount;
        _characterView.ShowHealPopUp(healthAmount);
        _characterView.OnHealthChange(_characterModel.CurrentHealth);
    }

    /*public int GetHealth()
    {
        return _characterModel.CurrentHealth;
    }*/
}

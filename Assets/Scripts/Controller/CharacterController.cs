using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class CharacterController : IController, IHealth
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

    public void Handle()
    {
        _characterView.OnUpdate();
    }
    
 


    public void Move()
    {
        throw new NotImplementedException();
    }

    public virtual void Attack()
    {
        
    }

    public virtual void TakeDamage(int damage)
    {
        _characterModel.CurrentHealth -= damage;
        _characterView.ShowDamagePopUp(damage);
        _characterView.OnHealthChange(_characterModel.CurrentHealth);
        if (_characterModel.CurrentHealth <= 0)
        {
            _characterView.OnAnimation(AnimationState.Die);
        }
    }

    public virtual void Heal(int healthAmount)
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

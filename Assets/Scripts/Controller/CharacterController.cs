using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using Object = UnityEngine.Object;

public abstract class CharacterController : BaseController, IController
{
    protected CharacterModel CharacterModel;
    protected CharacterView CharacterView;
    protected CharacterEvent CharacterEvent;

    protected GameObject Target; 
    protected bool Moving;

    public virtual void SetData(IModel characterModel, IView characterView,
        CharacterEvent characterEvent)
    {
        this.CharacterModel = (CharacterModel)characterModel;
        this.CharacterView = (CharacterView)characterView;
        this.CharacterEvent = characterEvent;
    }

    public virtual void Initialize()
    {
        EventRegister();
        
        CharacterView.Initialize();

        Moving = true;
        Target = null;
    }

    public virtual void Handle()
    {
        if(CharacterModel.IsDead)
            return;
        DetectTarget();
    }

    public void EventRegister()
    {
        CharacterEvent.OnTakeDamage += TakeDamage;
        CharacterEvent.OnHeal += Heal;
        CharacterEvent.OnAttack += Attack;
        CharacterEvent.OnDie += Die;
        CharacterEvent.OnGetHealth += GetHealth;
    }

    public void EventUnRegister()
    {
        CharacterEvent.OnTakeDamage -= TakeDamage;
        CharacterEvent.OnHeal -= Heal;
        CharacterEvent.OnAttack -= Attack;
        CharacterEvent.OnDie -= Die;
        CharacterEvent.OnGetHealth -= GetHealth;
    }


    public abstract void Move();
    protected abstract void Die();
    public abstract void DetectTarget();
    
    public virtual void Attack() // Attack when Event in Animation is trigger
    {
        var health = Target.GetComponent<IHealth>();
        health.TakeDamage(CharacterModel.DamageMin);
        if (health.GetHealth() <= 0)
        {
            health.Die();
            Target = null;
        }
    }

    public void TakeDamage(int damage)
    {
        CharacterModel.CurrentHealth -= damage;
        CharacterView.OnDamagePopUp(damage);
        CharacterView.OnHealthChange(CharacterModel.CurrentHealth);
    }

    protected virtual void Heal(int healthAmount)
    {
        CharacterModel.CurrentHealth += healthAmount;
        CharacterView.OnHealPopUp(healthAmount);
        CharacterView.OnHealthChange(CharacterModel.CurrentHealth);
    }


    private int GetHealth()
    {
        return CharacterModel.CurrentHealth;
    }
    
}
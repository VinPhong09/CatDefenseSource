using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using Object = UnityEngine.Object;

public class CharacterController : BaseController,IController
{
    protected CharacterModel CharacterModel;
    protected CharacterView CharacterView;
    protected CharacterEvent CharacterEvent;

    protected EnemyScripts ClosetEnemy;
    protected bool Moving;

    public void SetData(IModel characterModel, IView characterView,
        CharacterEvent characterEvent)
    {
        this.CharacterModel = (CharacterModel)characterModel;
        this.CharacterView = (CharacterView)characterView;
        this.CharacterEvent = characterEvent;
    }

    public void Initialize()
    {
        CharacterView.Initialize();
        EventRegister();

        Moving = true;
        ClosetEnemy = null;
    }

    public void Handle()
    {
        CharacterView.OnUpdate();
        DetectEnemies();
    }

    public void EventRegister()
    {
        CharacterEvent.OnTakeDamage += TakeDamage;
        CharacterEvent.OnHeal += Heal;
        CharacterEvent.OnAttack += Attack;
    }

    public void EventUnRegister()
    {
        CharacterEvent.OnTakeDamage -= TakeDamage;
        CharacterEvent.OnHeal -= Heal;
        CharacterEvent.OnAttack -= Attack;
    }


    public virtual void Move()
    {
        var position = CharacterView.GetPosition();
        ClosetEnemy.setIsChoose(true);
        if (Moving)
        {
            CharacterView.FlipObject(ClosetEnemy.gameObject);
            CharacterView.SetPosition(Vector2.MoveTowards(position, ClosetEnemy.transform.position,
                CharacterModel.MoveSpeed * Time.fixedDeltaTime));
            CharacterView.OnAnimation(AnimationState.Move);
        }
        
    }

    public virtual void Attack() // Attack Event in Animation
    {
        var enemyHealth = ClosetEnemy.GetComponent<EnemyHealth>();
        enemyHealth.addDamage(CharacterModel.DamageMin,"d");
    }

    public void DetectEnemies()
    {
        EnemyScripts[] allEnemy = Object.FindObjectsOfType<EnemyScripts>();
        foreach (EnemyScripts currenEnemy in allEnemy)
        {
            ClosetEnemy = currenEnemy;
        }
        if (ClosetEnemy == null)
        {
            CharacterView.OnAnimation(AnimationState.Idle);
            return;
        }
        Move();
        var position = CharacterView.GetPosition();
        if (Vector2.Distance(position, ClosetEnemy.transform.position) <= CharacterModel.AttackRange)
        {
            CharacterView.SetPosition(position);
            Moving = false;
            CharacterView.OnAnimation(AnimationState.NormalAttack);
        }
        else 
        {
            Moving = true;
        }
    }


    public void TakeDamage(int damage)
    {
        CharacterModel.CurrentHealth -= damage;
        CharacterView.ShowDamagePopUp(damage);
        CharacterView.OnHealthChange(CharacterModel.CurrentHealth);
        if (CharacterModel.CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healthAmount)
    {
        CharacterModel.CurrentHealth += healthAmount;
        CharacterView.ShowHealPopUp(healthAmount);
        CharacterView.OnHealthChange(CharacterModel.CurrentHealth);
    }

    public void Die()
    {
        CharacterView.OnAnimation(AnimationState.Die);
        EventUnRegister();
    }
    
}
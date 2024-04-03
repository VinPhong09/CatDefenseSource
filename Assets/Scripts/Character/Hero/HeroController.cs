using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class HeroController : CharacterController,  IController
{
    public override void Move()
    {
        var position = CharacterView.GetPosition();
        if (Moving)
        {
            CharacterView.FlipObject(Target);
            CharacterView.SetPosition(Vector2.MoveTowards(position, Target.transform.position,
                CharacterModel.MoveSpeed * Time.fixedDeltaTime));
            CharacterView.OnAnimation(AnimationState.Move);
        }
    }

    public override void DetectTarget()
    {
        var position = CharacterView.GetPosition();

        Collider2D[] enemies = Physics2D.OverlapCircleAll(position, 10f, LayerMask.GetMask("Enemy"));
        foreach (Collider2D currentEnemy in enemies)
        {
            Target = currentEnemy.gameObject;
        }
        if (Target == null)
        {
            CharacterView.OnAnimation(AnimationState.Idle);
            return;
        }
        Move();
        if (Vector2.Distance(position, Target.transform.position) <= CharacterModel.AttackRange)
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
    
    protected override void Heal(int healthAmount)
    {
        base.Heal(healthAmount);
    }
    protected override void Die()
    {
        Debug.Log("Hero Die");
        CharacterModel.IsDead = true;
        CharacterView.OnAnimation(AnimationState.Die);
    }
}

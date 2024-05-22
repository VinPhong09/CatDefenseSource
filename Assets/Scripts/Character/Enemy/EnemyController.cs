using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class EnemyController : CharacterController, IController
{
    public virtual void Initialize()
    {
        base.Initialize();
        Target = GameObject.FindGameObjectWithTag("Tower");
    }
    public override void Move()
    {
        var position = CharacterView.GetPosition();
        if (Moving)
        {
            position.x = Mathf.MoveTowards(position.x, Target.transform.position.x + 2,
                CharacterModel.MoveSpeed * Time.fixedDeltaTime);
            CharacterView.SetPosition(position);
            CharacterView.OnAnimation(AnimationState.Move);
        }
    }

    public override void DetectTarget()
    {
        if(Target == null)
            return;
        Move();
    }
    
    protected override void Die()
    {
        CharacterModel.IsDead = true;
        CharacterView.OnAnimation(AnimationState.Die);
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        CharacterView.gameObject.SetActive(false);
    }
}

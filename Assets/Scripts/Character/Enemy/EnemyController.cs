using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class EnemyController : CharacterController, IController
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
        
    }
}

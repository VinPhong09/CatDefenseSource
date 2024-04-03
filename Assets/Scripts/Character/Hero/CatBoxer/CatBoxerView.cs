using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoxerView : CharacterView, IView
{
    public override void OnAnimation(AnimationState animationState)
    {
        base.OnAnimation(animationState);
        switch (animationState)
        {
            case AnimationState.Skill1:
                break;
            case AnimationState.Skill2:
                break;
            case AnimationState.Skill3:
                break;
            
        }
    }
}

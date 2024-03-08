using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoxerView : CharacterView
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnAnimation(AnimationState animationState)
    {
        switch (animationState)
        {
            case AnimationState.Idle:
                break;
            case AnimationState.Move:
                break;
            case AnimationState.Die:
                break;
            case AnimationState.NormalAttack:
                break;
            case AnimationState.Skill1:
                break;
            case AnimationState.Skill2:
                break;
            case AnimationState.Skill3:
                break;
            
        }
    }
}

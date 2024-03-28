using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMuradView : CharacterView
{
    public override void Initialize() 
    {
        base.Initialize();
        CharacterAnimation = gameObject.GetComponentInChildren<Animator>();
    }
}

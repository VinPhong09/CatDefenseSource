using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class CatBoxerController : HeroController, IController
{
    public void SetData(IModel characterModel, IView characterView,
        CharacterEvent characterEvent)
    {
        base.SetData(characterModel, characterView, characterEvent);
    }

    public void Initialize()
    {
        base.Initialize();
        
        CharacterView.Initialize();
        EventRegister();

        Moving = true;
        ClosetEnemy = null;
    }
    
}
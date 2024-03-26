using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class GlobinAxeController : EnemyController, IController
{
    public void SetData(IModel characterModel, IView characterView,
        CharacterEvent characterEvent)
    {
        base.SetData(characterModel, characterView, characterEvent);
    }
}

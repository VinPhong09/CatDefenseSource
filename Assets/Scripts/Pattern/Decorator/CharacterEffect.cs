using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterEffect : ICharacterEffect
{
    protected ICharacterEffect _character;

    public CharacterEffect(ICharacterEffect character)
    {
        _character = character;
    }

    public abstract void OnEffect();

    public abstract void DisableEffect();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHeroButton : BaseButton
{
    private CharacterName _characterName;
    
    public void SetData(CharacterName characterName)
    {
        _characterName = characterName;
    }
    protected override void OnClick()
    {
        CharacterManager.Instance.CreateHeroByName(_characterName);
        this.button.interactable = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class CharacterFactory : BaseFactory<CharacterModel,CharacterView,CharacterController>
{
    public override void Create(CharacterType characterType, CharacterName characterName)
    {
        switch (characterType)
        {
            case CharacterType.Hero:
                CreateHeroByName(characterName);
                break;
            case CharacterType.Enemy:
                CreateEnemyByName(characterName);
                break;
            case CharacterType.Pet:
                CreatePetByName(characterName);
                break;
        }
    }
    private void CreateHeroByName(CharacterName characterName)
    {
        switch (characterName)
        {
            case CharacterName.CatBoxer:
                CreateObject(CharacterName.CatBoxer,new CatBoxerModel(),new CatBoxerController());
                break;
            
        }
    }
    private void CreateEnemyByName(CharacterName characterName)
    {
        throw new System.NotImplementedException();
    }
    
    private void CreatePetByName(CharacterName characterName)
    {
        throw new System.NotImplementedException();
    }

    public void CreateObject(CharacterName characterName,CharacterModel characterModel,
        IController characterController)
    {
        var prefab = Resources.Load<GameObject>("Prefabs/Character/"+characterName.ToString());
        var gameObject = GameObject.Instantiate(prefab);
        var characterEvent = gameObject.AddComponent<CharacterEvent>();
        var Model = characterModel;
        var View = gameObject.GetComponent<IView>();
        var Controller = characterController;
        Controller.SetData(Model,View,characterEvent);
        Controller.Initialize();
    }

    
}

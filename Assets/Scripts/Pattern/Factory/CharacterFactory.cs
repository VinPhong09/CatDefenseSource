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
        var position = SpawnManager.Instance.HeroSpawnPoint.transform;

        CharacterType characterHero = CharacterType.Hero;
        switch (characterName)
        {
            case CharacterName.CatBoxer:
                CreateObject(characterHero, characterName,new CatBoxerModel(),new CatBoxerController(),position);
                break;
            
        }
    }
    private void CreateEnemyByName(CharacterName characterName)
    {
        var position = SpawnManager.Instance.EnemySpawnPoint.transform;

        CharacterType characterEnemy = CharacterType.Enemy;
        switch (characterName)
        {
            case CharacterName.GlobinAxe:
                CreateObject(characterEnemy, characterName,new GlobinAxeModel(),new GlobinAxeController(),position);
                break;
            
        }
    }
    
    private void CreatePetByName(CharacterName characterName)
    {
        throw new System.NotImplementedException();
    }

    public void CreateObject(CharacterType characterType, CharacterName characterName,CharacterModel characterModel,
        IController characterController, Transform position)
    {
        var parent = CharacterManager.Instance.gameObject.transform;
        var prefab = Resources.Load<GameObject>("Prefabs/Character/"+characterType.ToString()+"/"+characterName.ToString());
        var gameObject = GameObject.Instantiate(prefab, position, parent);
        var characterEvent = gameObject.AddComponent<CharacterEvent>();
        var model = characterModel;
        var view = gameObject.GetComponent<IView>();
        var controller = characterController;
        controller.SetData(model,view,characterEvent);
        controller.Initialize();
        CharacterManager.Instance.AddController(characterName, controller);
        CharacterManager.Instance.AddCharacter(characterType, characterName, gameObject);
    }
}

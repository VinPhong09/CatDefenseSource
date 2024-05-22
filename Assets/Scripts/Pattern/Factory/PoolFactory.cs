using System;
using System.Collections;
using System.Collections.Generic;
using Interface;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VinExtension;

public class PoolFactory : MonoBehaviour
{
    public IController CreateEnemyControllerByName(CharacterName characterName)
    {
        switch (characterName)
        {
            case CharacterName.GlobinAxe:
                return new GlobinAxeController();
        }
        return null;
    }
    public CharacterModel CreateEnemyModelByName(CharacterName characterName)
    {
        switch (characterName)
        {
            case CharacterName.GlobinAxe:
                return new GlobinAxeModel();
        }
        return null;
    }

    public Dictionary<GameObject, IController> CreatePool(GameObject gameObject, Transform enemySpawnPoint)
    {
        Debug.Log("CreatePool");
        var newDict = new Dictionary<GameObject, IController>();
        var newGameObject = Instantiate(gameObject, enemySpawnPoint.position, Quaternion.identity);
        newGameObject.name = gameObject.name;
        var characterName = EnumParse.StringToEnum<CharacterName>(newGameObject.name);
        var newView = newGameObject.GetComponent<CharacterView>();
        var newEvent = newView.GetComponent<CharacterEvent>();
        var newModel = CreateEnemyModelByName(characterName);
        var newController = CreateEnemyControllerByName(characterName);
        newController.SetData( newModel, newView, newEvent, new MeeleAttack());
        newGameObject.SetActive(false);
        newController.Initialize();
        newDict.Add(newGameObject, newController);
        return newDict;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;

public class CharacterManager : Singleton<CharacterManager>
{
    private Dictionary<CharacterType, Dictionary<CharacterName, GameObject>> _charactersDictionary;
    private Dictionary<CharacterType,Dictionary<CharacterName,IController>> _controllersDictionary;
    
    private CharacterFactory _characterFactory;
    private IController _characterController;

    public void Initialize()
    {
        _controllersDictionary = new Dictionary<CharacterType,Dictionary<CharacterName, IController>>();
        _charactersDictionary = new Dictionary<CharacterType, Dictionary<CharacterName, GameObject>>();
        _characterFactory = new CharacterFactory();
    }

    public void CreateCharacter()
    {
        _characterFactory.Create(CharacterType.Enemy,CharacterName.GlobinAxe);
        
    }

    public void CreateHeroByName(CharacterName characterName)
    {
        _characterFactory.CreateHeroByName(characterName);
    }
    public void Handle()
    {
        HandleController();
    }

    public void AddController(CharacterType type, CharacterName key,IController value)
    {
        GetControllersDictionaryByType(type).Add(key,value);
    }

    public void AddCharacterGameObject(CharacterType type, CharacterName characterName, GameObject gameObject)
    {
        GetCharacterGameObjectsDictionaryByType(type).Add(characterName, gameObject);
    }

    public void RemoveCharacterByName()
    {
        
    }

    public  Dictionary<CharacterName,GameObject> GetCharacterGameObjectsDictionaryByType(CharacterType type)
    {
        if (_charactersDictionary.ContainsKey(type))
        {
            return _charactersDictionary[type];
        }
        else
        {
            //If not exist create a new dictionary by type.
            _charactersDictionary.Add(type, new Dictionary<CharacterName, GameObject>());
            return _charactersDictionary[type];
        }
    }
    public  Dictionary<CharacterName,IController> GetControllersDictionaryByType(CharacterType type)
    {
        if (_controllersDictionary.ContainsKey(type))
        {
            return _controllersDictionary[type];
        }
        else
        {
            //If not exist create a new dictionary by type.
            _controllersDictionary.Add(type, new Dictionary<CharacterName, IController>());
            return _controllersDictionary[type];
        }
        return null;
    }
    public GameObject GetHeroByName(CharacterName characterName)
    {
        var characters = GetCharacterGameObjectsDictionaryByType(CharacterType.Hero);
        if (characters.ContainsKey(characterName))
            return characters[characterName];
        else
        {
            return null;
        }
    }

    public List<GameObject> GetHeroGameObjectList()
    {
        var dictionarys = GetCharacterGameObjectsDictionaryByType(CharacterType.Hero);
        var heros = new List<GameObject>();
        foreach (var x in dictionarys)
        {
            heros.Add(x.Value);
        }

        return heros;
    }

    public List<IController> GetHeroControllerList()
    {
        var dictionary = GetControllersDictionaryByType(CharacterType.Hero);
        var _heroControllers = new List<IController>();
        foreach (var x in dictionary)
        {
            _heroControllers.Add(x.Value);
        }

        return _heroControllers;
    }
    private void HandleController()
    {
        if(_controllersDictionary == null)
            return;
        foreach (var controllers in _controllersDictionary)
        {
            
            foreach (var controller in controllers.Value)
            {
                
                controller.Value.Handle();
            }
        }
    }
    
    
}
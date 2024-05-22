using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;

public class CharacterManager : Singleton<CharacterManager>
{
    private Dictionary<CharacterType, Dictionary<CharacterName, Dictionary<GameObject,IController>>> _charactersDictionary;
    
    private CharacterFactory _characterFactory;
    private IController _characterController;

    public void Initialize()
    {
        _charactersDictionary = new Dictionary<CharacterType, Dictionary<CharacterName, Dictionary<GameObject, IController>>>();
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

    public void AddCharacterToDictionary(CharacterType type, CharacterName characterName, GameObject gameObject ,IController controller)
    {
        var characterTypeDictionary = GetCharacterTypeDictionary(type);
        if(!characterTypeDictionary.ContainsKey(characterName))
            characterTypeDictionary.Add(characterName,new Dictionary<GameObject, IController>());
        foreach (var characterNameDictionary in characterTypeDictionary)
        {
            if (characterNameDictionary.Key.Equals(characterName))
            {
                characterNameDictionary.Value.Add(gameObject, controller);
            }
        }
    }

    public void RemoveCharacterByName()
    {
        
    }

    public Dictionary<CharacterName, Dictionary<GameObject, IController>> GetCharacterTypeDictionary(
        CharacterType characterType)
    {
        if (!_charactersDictionary.ContainsKey(characterType))
        {
            //Create when Dictionary not exist
            _charactersDictionary.Add(characterType, new Dictionary<CharacterName, Dictionary<GameObject, IController>>());
        }
        return _charactersDictionary[characterType];
    } 
    public  List<Dictionary<GameObject,IController>> GetCharacterGameObjectsDictionaryByType(CharacterType type)
    {
        var Dict = new List<Dictionary<GameObject, IController>>();
        foreach (var characterNameDictionary in GetCharacterTypeDictionary(type))
        {
            Dict.Add(characterNameDictionary.Value);
        }
        return Dict;
    }
   
   
    public List<GameObject> GetHeroGameObjectList()
    {
        var dictionarys = GetCharacterGameObjectsDictionaryByType(CharacterType.Hero);
        var heros = new List<GameObject>();
        foreach (var x in dictionarys)
        {
            foreach (var y in x)
            {
                heros.Add(y.Key);
            }
        }

        return heros;
    }

    public List<IController> GetHeroControllerList()
    {
        var dictionary = GetCharacterGameObjectsDictionaryByType(CharacterType.Hero);
        Debug.Log("DictCount: " + dictionary.Count);
        var _heroControllers = new List<IController>();
        foreach (var x in dictionary)
        {
            foreach (var y in x)
            {
                _heroControllers.Add(y.Value);
            }
        }
        return _heroControllers;
    }
    public List<GameObject> GetEnemyGameObjectList()
    {
        var dictionarys = GetCharacterGameObjectsDictionaryByType(CharacterType.Enemy);
        var enemys = new List<GameObject>();
        foreach (var x in dictionarys)
        {
            foreach (var y in x)
            {
                enemys.Add(y.Key);
            } 
        }

        return enemys;
    }
   
    
    private void HandleController()
    {
        if(_charactersDictionary == null)
            return;
        foreach (var dict in _charactersDictionary)
        {
            foreach (var dict2 in dict.Value)
            {
                foreach (var controller in dict2.Value)
                {
                    if(controller.Key.activeInHierarchy)
                        controller.Value.Handle();
                }
            }
        }
    }
    
    
}
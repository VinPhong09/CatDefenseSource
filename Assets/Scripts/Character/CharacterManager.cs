using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;

public class CharacterManager : Singleton<CharacterManager>
{
    private Dictionary<CharacterType, Dictionary<CharacterName, GameObject>> _charactersDictionary;
    private Dictionary<CharacterName,IController> _controllersDictionary;
    
    private CharacterFactory _characterFactory;
    private IController _characterController;

    public void Initialize()
    {
        _controllersDictionary = new Dictionary<CharacterName, IController>();
        _charactersDictionary = new Dictionary<CharacterType, Dictionary<CharacterName, GameObject>>();
        _characterFactory = new CharacterFactory();
    }

    public void CreateCharacter()
    {
        _characterFactory.Create(CharacterType.Hero,CharacterName.CatBoxer);
    }
    public void Handle()
    {
        HandleController();
    }

    public void AddController(CharacterName key,IController value)
    {
        _controllersDictionary.Add(key, value);
    }

    public void AddCharacter(CharacterType key, CharacterName characterName, GameObject gameObject)
    {
        var dict = new Dictionary<CharacterName, GameObject>();
        dict.Add(characterName, gameObject);
        _charactersDictionary.Add(key, dict);
    }

    public void RemoveCharacterByName()
    {
        
    }

    private void HandleController()
    {
        foreach (var controller in _controllersDictionary)
        {
            controller.Value.Handle();
        }
    }
    
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Interface;

public class CharacterManager : MonoBehaviour
{
    private CharacterFactory _characterFactory;
    
    private List<IController> _controllers;
    private IController _characterController;
    
    public void Initialize()
    {
        _controllers = new List<IController>();
    }

    public void CreateCharacter()
    {
        _characterFactory = new CharacterFactory();
        _characterFactory.Create(CharacterType.Hero,CharacterName.CatBoxer);
    }
    public void Handle()
    {
        _characterController.Handle();
    }

    public void AddController(IController controller)
    {
        _controllers.Add(controller);
    }
    public List<Character> allCharacters;

    public void AddCharacter(Character character)
    {
        allCharacters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        allCharacters.Remove(character);
    }

    public Character GetCharacterByName(string name)
    {
        return allCharacters.Find(character => character._Name == name);
    }
}
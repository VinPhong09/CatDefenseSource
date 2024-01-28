using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterManager : MonoBehaviour
{
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
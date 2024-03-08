using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoxerModel : CharacterModel
{
    public CatBoxerModel()
    {
        MoveSpeed = 2;
        //set BeginLevel
        Level = 1;
        CurrentExp = 0;
        ExpToUplevel = 100;
        
        //Set Begin Damage
        DamageLevel = 0;
        DamageMax = 12;
        DamageMin = 8;
        
        //Set Begin Health
        MaxHealth = 200;
        
        //Set RageDMG
        RateDamage = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMuradModel : CharacterModel
{
    public CatMuradModel()
    {
        MoveSpeed = 2;
        AttackSpeed = 0.5f;
        AttackRange = 2f;
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
        CurrentHealth = MaxHealth;
        
        //Set CritRate
        CritRate = 0;

        IsDead = false;
    }
}

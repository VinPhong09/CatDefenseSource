using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel 
{
    [Header("Character Properties")]
    public float MoveSpeed { get; set; }

    public int Level { get; set; }
    public float Exp { get; set; }
    public float CurrentExp { get; set; }
    public float ExpToUplevel { get; set; }

    public int DamageLevel { get; set; }
    public int DamageMin { get; set; }
    public int DamageMax { get; set; }
    
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    public float RateDamage { get; set; }

    public bool IsFight { get; set; }
    public bool IsUnlock { get; set; }
    public bool IsDead { get; set; }

  
}

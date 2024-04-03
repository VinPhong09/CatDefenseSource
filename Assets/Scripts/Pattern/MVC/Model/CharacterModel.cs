using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : BaseModel, IModel
{
    [Header("Character Stat")]
    public float MoveSpeed { get; set; }
    
    public float AttackRange { get; set; }
    public float AttackSpeed { get; set; }
    public int Level { get; set; }
    public float Exp { get; set; }
    public float CurrentExp { get; set; }
    public float ExpToUplevel { get; set; }

    public int DamageLevel { get; set; }
    public int DamageMin { get; set; }
    public int DamageMax { get; set; }
    
    public float LifeSteal { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }

    public float CritRate { get; set; }

    public bool IsFight { get; set; }
    public bool IsUnlock { get; set; }
    public bool IsDead { get; set; }

    public Dictionary<string, ISkill> Skills;

    public override void Initialize()
    {
        Skills = new Dictionary<string, ISkill>();
    }
}

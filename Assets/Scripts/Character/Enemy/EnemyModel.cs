using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : CharacterModel, IModel
{
    public EnemyModel()
    {
        MoveSpeed = 2;
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        DamageMin = 2;
    }
}

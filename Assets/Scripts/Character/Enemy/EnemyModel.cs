using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : CharacterModel, IModel
{
    public EnemyModel()
    {
        MoveSpeed = 0;
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
        DamageMin = 2;
    }
}

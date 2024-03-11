using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public SkillData skillDataSO;

    public void Initialize()
    {
        
    }
    public void SetDamage(int Damage)
    {
        skillDataSO.DamagePercentage += Damage;
    }

}

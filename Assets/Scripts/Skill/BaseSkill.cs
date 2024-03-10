using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public SkillData SkillDataSo;

    public void Initialize()
    {
        
    }
    public void SetDamage(int Damage)
    {
        SkillDataSo.DamagePercentage += Damage;
    }

}

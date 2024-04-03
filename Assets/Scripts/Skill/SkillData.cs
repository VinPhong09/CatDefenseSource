using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SkillDataSO", menuName = "ScriptableObjects/SkillDataSO", order = 1)]
public class SkillData : ScriptableObject
{
    public string Name;
    public Sprite Image;
    public string Description;
    public SkillEffect SkillEffect;
    public float DamagePercentage;
    public string Level;
    public bool IsUnlock;
    public bool HasUpgrade;
}

public enum SkillEffect
{
    NoEffect,
    LifeSteal,
    Healing,
    BuffShield,
    BuffAttackSpeed,
    BuffDamage,
}

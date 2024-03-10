using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillData : ScriptableObject
{
    public string Name { get; set; }
    public Sprite Image{ get; set; }
    public string Description{ get; set; }
    public float DamagePercentage{ get; set; }
    public string Level{ get; set; }
    public bool IsUnlock { get; set; }
    
}

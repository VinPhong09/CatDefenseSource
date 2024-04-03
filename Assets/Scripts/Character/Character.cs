using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System;

[SerializeField]
public class Character : MonoBehaviour
{
    [Header("Character Infomation")]
    public string _Name;
    public Sprite _Image;
    public string _Description;
    public GameObject _AnimationPreview;

    [Header("Character Properties")]
    public float _MoveSpeed;

    public int _Level = 1;
    public float _Experience;

    public int _Damage;
    public int _MaxHealth;
    public int _CurrentHealth;

    public float _CritRate;

    public bool _isFight;
    public bool _isUnlock;
    public bool _isDead;

    [Header("UI")]
    public GameObject _PopUpDamage;
    public GameObject _PopUpHealth;
    public Slider _HealthBarSlider;
    public Canvas _CanVasUI;
    [Header("Skill information")]
    public List<Skill> _Skills;
    
}

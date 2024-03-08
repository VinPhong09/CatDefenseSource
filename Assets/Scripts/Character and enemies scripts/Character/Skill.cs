using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
  public class Skill 
{
        public string _Name;
        public Sprite _Image;
        public string _Description;
        public float _DamagePercentage;
        public string _Level;
        public bool _isUnlock;

        
        public void setDamageUp(int _addDamage)
        {
            _DamagePercentage += _addDamage;
        }
        
}

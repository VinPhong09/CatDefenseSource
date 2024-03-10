using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CatVampireProperties : MonoBehaviour
{

    int _DamageLevel, _DamageMin, _DamageMax;
    float _RateBlood,_MaxHealth,CritDamage;
    
    public Slider _ExpSlider;
    float _CurrenVelocity = 0;
    //Get Component
    CatVampireScripts _CharScripts;
    CharHealth _CharHealth;

    //Exp Variable
    [SerializeField] protected TextMeshProUGUI _TextLevel;


    private int _Level;  


    private int _CurrentExp;

    private int _ExpToUplevel;

    float _RateDamageSkill,_RateBloodSkill;
    // Start is called before the first frame update
    void Awake(){
        _CharHealth = this.gameObject.GetComponent<CharHealth>();
        _MaxHealth = 100;
        _CharHealth._MaxHealth = this._MaxHealth;
    } 
    void Start()
    {
        //Get Component
        _CharScripts = this.gameObject.GetComponent<CatVampireScripts>();
        //set BeginLevel
        _Level = 1;
        _CurrentExp = 0;
        _ExpToUplevel = 100;
        _ExpSlider.maxValue = _ExpToUplevel;
        _TextLevel.text = "LV" + _Level;

        _RateBlood = 0.3f;
        //Set Begin Damage
        _DamageLevel = 0;
        _DamageMax = 20;
        _DamageMin = 14;
        //Set RageDMGskill
        _RateDamageSkill = 2.5f;
        _RateBloodSkill = 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        ExpSlider();
    }

     public float GetDamage()
    {
        return Random.Range(_DamageMin + _DamageLevel, _DamageMax + _DamageLevel) * _RateDamageSkill;
    }

    public int GetTextDamageMax()
    {
        return _DamageMax;
    }
    public int GetTextDamageMin()
    {
        return _DamageMin;
    }
    public int GetTextHealth()
    {
        return _CharHealth.GetTextMaxHealth();
    }

    public int GetTextLevel()
    {
        return _Level;
    }
    public void SetRateDMGskill1()
    {
        _RateDamageSkill += 0.4f;
    }
    public float GetRateDMGskill1()
    {
        return _RateDamageSkill;
    }

    public void UpRateBlood()
    {
        _RateBloodSkill += 0.05f;
    }
    void setRateBlood(float _rate)
    {
        _RateBlood += _rate;
    }


     public float GetRateBlood()
    {
        return _RateBlood + _RateBloodSkill;
    }
    public float GetRateBloodEffect()
    {
        return _RateBloodSkill;
    }

    public void addExp(int exp)
    {
        _CurrentExp += exp;
        if(_CurrentExp >= _ExpToUplevel)
        {
            _CurrentExp = 0;
            LevelUp();
        }
    }
    public void UpLevel()
    {
        LevelUp();
    }
    void ExpSlider()
    {

        float _CurrenValue = Mathf.SmoothDamp(_ExpSlider.value,_CurrentExp, ref _CurrenVelocity, 200*Time.deltaTime);
        _ExpSlider.value = _CurrenValue;

        _TextLevel.text = "LV" + _Level;
        _ExpSlider.maxValue = _ExpToUplevel;
    }

    public void LevelUp()
    {
        int DamageRange = Random.Range(5,10);
        _ExpToUplevel += 50;
        _Level += 1;
        _DamageMin += DamageRange;
        _DamageMax += DamageRange;
        _CharHealth.SetMaxHealth(50);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CatMuradProperties : MonoBehaviour
{

    int _DamageLevel, _DamageMin, _DamageMax;
    float _RateBlood,_MaxHealth,CritDamage;
    
    public Slider _ExpSlider;
    float _CurrenVelocity = 0;
    //Get Component
    CatMuradScripts _CharScripts;
    CharHealth _CharHealth;
    //Exp Variable
    [SerializeField] protected TextMeshProUGUI _TextLevel;


    private int _Level;


    private int _CurrentExp;

    private int _ExpToUplevel;

    float _RateDamegeSkill1,_RateDamegeSkill2;
    // Start is called before the first frame update
    void Awake(){
        _CharHealth = this.gameObject.GetComponent<CharHealth>();
        _MaxHealth = 100;
        _CharHealth._MaxHealth = this._MaxHealth;
    } 
    void Start()
    {
        //Get Component
        _CharScripts = this.gameObject.GetComponent<CatMuradScripts>();
    
        //set BeginLevel
        _Level = 1;
        _CurrentExp = 0;
        _ExpToUplevel = 100;
        _ExpSlider.maxValue = _ExpToUplevel;
        _TextLevel.text = "LV" + _Level;

        _RateBlood = 0.1f;
        //Set Begin Damage
        _DamageLevel = 0;
        _DamageMax = 20;
        _DamageMin = 14;
        //Set RageDMGskill
        _RateDamegeSkill1 = 2f;
        _RateDamegeSkill2 = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        ExpSlider();
    }

     public float GetDamage()
    {
        return Random.Range(_DamageMin + _DamageLevel, _DamageMax + _DamageLevel)*_RateDamegeSkill1;
    }

    public float GetDamageSkill1()
    {
        return Random.Range(_DamageMin + _DamageLevel, _DamageMax + _DamageLevel) * _RateDamegeSkill1;
    }

    public float GetDamageSkill2()
    {
        return Random.Range(_DamageMin + _DamageLevel, _DamageMax + _DamageLevel) * _RateDamegeSkill2;
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

    public void StartCoroutineEffect(float _rate)
    {
        StartCoroutine(setRateBloodBeforeEffect(_rate));
    }
    IEnumerator setRateBloodBeforeEffect(float _rate)
    {
        _RateBlood = _rate;
        Debug.Log("SetRate");
        StartCoroutine(setRateBloodAfterEffect(15f));
        yield return null;
    }

    IEnumerator setRateBloodAfterEffect(float _delaytime)
    {
         yield return new WaitForSeconds(_delaytime);
         Debug.Log("UnBBlodd");
        _RateBlood = 0;
    }

    public void SetRateDMGskill1()
    {
        _RateDamegeSkill1 += 0.2f;
    }

    public void SetRateDMGskill2()
    {
        _RateDamegeSkill2 += 0.2f;
    }


    public float GetRateDMGskill1()
    {
        return _RateDamegeSkill1;
    }

    public float GetRateDMGskil2()
    {
        return _RateDamegeSkill2;
    }

    void setRateBlood(float _rate)
    {
        _RateBlood = _rate;
    }


     public float GetRateBlood()   
    {
        return _RateBlood;
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
        int DamageRange = Random.Range(3,6);
        _ExpToUplevel += 50;
        _Level += 1;
        _DamageMin += DamageRange;
        _DamageMax += DamageRange;
        _CharHealth.SetMaxHealth(50);
    }
}

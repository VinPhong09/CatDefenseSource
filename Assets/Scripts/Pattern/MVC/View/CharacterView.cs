using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterView : BaseView, IView
{
    [Header("UI")]
    public GameObject popupDamage;
    public GameObject popupHealth;
    public TextMeshProUGUI txtLevel;
    public Canvas characterUI;
    public List<CharacterSlider> sliders;
    
    [Header("Skill UI")]
    public List<SkillData> Skills;

    protected CharacterEvent CharacterEvent;
    protected Animator CharacterAnimation;
    
    private float _smootTimeUIBar = 2;
    public virtual void Initialize()
    {
        CharacterAnimation = gameObject.GetComponent<Animator>();
        CharacterEvent = gameObject.GetComponent<CharacterEvent>();
        InitValueUIBar();
        EventRegister();
    }
    public void EventRegister()
    {
        
    }

    #region UI Handle
    
    // Popup
    public void OnDamagePopUp(int damage)
    {
        ShowPopup(damage, popupDamage);
    }
    
    public void OnHealPopUp(int damage)
    {
        ShowPopup(damage, popupHealth);
    }
    private void ShowPopup(int value, GameObject popup)
    {
        GameObject textDamage = Instantiate(popup,new Vector2(gameObject.transform.position.x + Random.Range(-0.1f,0.2f) ,gameObject.transform.position.y + Random.Range(1.4f,1.7f)),Quaternion.identity); 
        textDamage.GetComponent<TextMesh>().text = " " + value.ToString();
    }
    // Slider
    public void InitValueUIBar()
    {
        var healthBar = GetSliderByType(SliderType.HealthBar);
        var health = CharacterEvent.GetHealth();
        healthBar.maxValue = health;
        healthBar.value = health;
    }
    public void OnExpChange(int exp)
    {
        var expBar = GetSliderByType(SliderType.ExpBar);
        SetValueUIBar(exp, expBar);
    }

    public void OnEnergyChange(int value)
    {
        var energyBar = GetSliderByType(SliderType.EnergyBar);
        SetValueUIBar(value, energyBar);
    }
    public void OnHealthChange(int health)
    {
        var healthBar = GetSliderByType(SliderType.HealthBar);
        SetValueUIBar(health, healthBar);
    }
    private void SetValueUIBar(int value, Slider slider)
    {
        slider.DOValue(value, _smootTimeUIBar, false);
    }
    // Text
    public void OnLevelChange(int level)
    {
        txtLevel.text = "LV " + level;
    }

    public Slider GetSliderByType(SliderType sliderType)
    {
        foreach (var slider in sliders)
        {
            if (sliderType == slider.sliderType)
                return slider.slider;
        }
        return null;
    }
    #endregion

    #region Animation Handle

    public virtual void OnAnimation(AnimationState animationState)
    {
        switch (animationState)
        {
            case AnimationState.Idle:
                CharacterAnimation.CrossFade(AnimationState.Idle.ToString(), 0);
                break;
            case AnimationState.Move:
                CharacterAnimation.CrossFade(AnimationState.Move.ToString(), 0);
                break;
            case AnimationState.NormalAttack:
                CharacterAnimation.CrossFade(AnimationState.NormalAttack.ToString(), 0);
                break;
            case AnimationState.Die:
                CharacterAnimation.CrossFade(AnimationState.Die.ToString(), 0);
                break;
        }
    }

    public virtual void SetAnimationSpeed(AnimationParams animationParams, float speed)
    {
        CharacterAnimation.SetFloat(animationParams.ToString(),speed);
    }
    public void OnAttack()
    {
        CharacterEvent.Attack();
    }
    #endregion

    #region Transform Handle

    public void SetPosition(Vector2 position)
    {
        gameObject.transform.position = position;
    }

    public Vector2 GetPosition()
    {
        var position = gameObject.transform.position;
        return new Vector2(position.x, position.y);
    }

    
    public void FlipObject(GameObject ob)
    {
        
        Vector2 scaleOb = transform.localScale;
        Vector2 scaleUI = characterUI.transform.localScale;

        if(transform.position.x > ob.transform.position.x)
        {
            scaleOb.x = Mathf.Abs(scaleOb.x) * -1; 
            scaleUI.x = Mathf.Abs(scaleUI.x) * -1;
        }
        else
        {
            scaleOb.x = Mathf.Abs(scaleOb.x);
            scaleUI.x = Mathf.Abs(scaleUI.x);
        }
        transform.localScale = scaleOb;
        characterUI.transform.localScale = scaleUI;
    }
    #endregion

    public List<SkillData> GetSkillList() => Skills;
    
}

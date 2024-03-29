using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterView : BaseView, IView
{
    [Header("UI")]
    public GameObject popupDamage;
    public GameObject popupHealth;
    public Slider healthBarSlider;
    public Canvas characterUI;
    
    [Header("Skill UI")]
    public List<Skill> skills;

    protected CharacterEvent CharacterEvent;
    protected Animator CharacterAnimation;
    
    private float _currentVelocity = 0;
    
    public void Initialize()
    {
        CharacterAnimation = gameObject.GetComponent<Animator>();
        CharacterEvent = gameObject.GetComponent<CharacterEvent>();
        
        EventRegister();
    }

    public void EventRegister()
    {
    }
    public void OnUpdate()
    {
    }

    #region UI Handle
    
    public void ShowDamagePopUp(float damage)
    {
        GameObject textDamage = Instantiate(popupDamage,new Vector2(gameObject.transform.position.x + Random.Range(-0.1f,0.2f) ,gameObject.transform.position.y + Random.Range(1.4f,1.7f)),Quaternion.identity); 
        textDamage.GetComponent<TextMesh>().text = " " + damage.ToString();
    }
    
    public void ShowHealPopUp(float damage)
    {
        GameObject textDamage = Instantiate(popupHealth,new Vector2(gameObject.transform.position.x + Random.Range(-0.1f,0.2f) ,gameObject.transform.position.y + Random.Range(1.4f,1.7f)),Quaternion.identity); 
        textDamage.GetComponent<TextMesh>().text = " " + damage.ToString();
    }
    
    public void OnHealthChange(float currentHealth)
    {
        float currentValue = Mathf.SmoothDamp(healthBarSlider.value,currentHealth, ref _currentVelocity, 20*Time.deltaTime); //  Smooth Slider
        healthBarSlider.value = currentValue;
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
    
}

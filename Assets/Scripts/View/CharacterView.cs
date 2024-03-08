using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CharacterView : MonoBehaviour
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
    private float _moveSpeed = 2;
    
    public void Initialize()
    {
        CharacterAnimation = gameObject.GetComponent<Animator>();
        CharacterEvent = gameObject.GetComponent<CharacterEvent>();
    }

    public void EventRegister()
    {
        
    }
    // Update is called once per frame
    public void OnUpdate()
    {
        Move();
    }

    #region UI Handle
    
    public void ShowDamagePopUp(float damage)
    {
        GameObject TextDamage = Instantiate(popupDamage,new Vector2(gameObject.transform.position.x + Random.Range(-0.1f,0.2f) ,gameObject.transform.position.y + Random.Range(1.4f,1.7f)),Quaternion.identity); 
        TextDamage.GetComponent<TextMesh>().text = " " + damage.ToString();
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

    public abstract void OnAnimation(AnimationState animationState);

    #endregion

    #region Action Handle
    public void Move()
    {
        Debug.Log("Move");
                EnemyScripts _ClosetE;
                _ClosetE = null;
                EnemyScripts [] _AllEnemy = GameObject.FindObjectsOfType<EnemyScripts>();

                foreach(EnemyScripts _CurrenEnemy in _AllEnemy)
                {
                        _ClosetE = _CurrenEnemy;
                }
                
            if(_ClosetE != null)
            {
                
                    _ClosetE.setIsChoose(true);
                    flipObject(_ClosetE.gameObject);
                    
                    gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _ClosetE.transform.position,_moveSpeed * Time.fixedDeltaTime);

                    if(Vector2.Distance(gameObject.transform.position,_ClosetE.transform.position) <= 0.07f)
                    {
                        OnAnimation(AnimationState.NormalAttack);
                    }

                    if(Vector2.Distance(gameObject.transform.position,_ClosetE.transform.position) >= 0.1f)
                    {
                        OnAnimation(AnimationState.Idle);
                        
                    }
                    
            }

    }

    
    public void flipObject(GameObject Ob)
    {
        
        Vector2 scaleOb = transform.localScale;
        Vector2 scaleUI = characterUI.transform.localScale;

        if(transform.position.x > Ob.transform.position.x)
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

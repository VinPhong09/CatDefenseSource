using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatBoxerScripts : MonoBehaviour
{


    // Basic Variable
    [SerializeField] protected float _MoveSpeed;
    [SerializeField] protected GameObject _CallBackPosition;

    [SerializeField] protected Canvas _CanVasUI;

    bool _isBloodRestone = false;

    float _CountTime;

    bool _isCallBack = false;

    bool _CanSkill2 = true;
    public bool _CanSkill3 = true;



    //bool _isAttack = false;
    Vector2 _Target;
    Rigidbody2D _RG;
    public Animator _Anim;

    public Animation _Animation;

    CatBoxerFindEnemyToAttack _findEnemyToAttack;

    CatBoxerAttack _CatBoxerAttack;

    CatBoxerProperties _CharProperties;
    CharHealth _CharHealth;

    // Start is called before the first frame update
    void Start()
    {
        _RG = gameObject.GetComponent<Rigidbody2D>();
        _Anim = gameObject.GetComponentInChildren<Animator>();
        _findEnemyToAttack = gameObject.GetComponent<CatBoxerFindEnemyToAttack>();
        _CatBoxerAttack = gameObject.GetComponentInChildren<CatBoxerAttack>();
        _CharHealth = gameObject.GetComponent<CharHealth>();
        _CharProperties = gameObject.GetComponent<CatBoxerProperties>();
        //
    }

    void Update()
    {
        if(_isBloodRestone)
            BloodRestoneEffectTime();
        // Delay time Reborn
        if(_CharHealth.getDead())
        {
            IsReborn();
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CallBackCharacter();
    }   

#region Check Detect Collider and Attack 
   private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "BloodRestone" )
        {
            CatVampireProperties catVPPrope = other.gameObject.GetComponentInParent<CatVampireProperties>();
            _CharProperties.StartCoroutineEffect(catVPPrope.GetRateBloodEffect());
            _isBloodRestone = true; 
        }
    }
#endregion


    void CallBackCharacter()
    {
        if(Vector2.Distance(gameObject.transform.position,_CallBackPosition.transform.position) < 0.1f)
        {
            _isCallBack = false;

             AttackManagement(false);

             Move(false); Idle(true);

             flipObject(gameObject);
             
        }
            
        if(_isCallBack)
        {
            //Move to target
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,_CallBackPosition.transform.position , _MoveSpeed * Time.fixedDeltaTime);
            Move(true);
            AttackManagement(false);
            //Flop when Calling Back
            flipObject(_CallBackPosition);
        }
        
    }
    public void isKillerEnemy()
    {
        AttackManagement(false);
        _findEnemyToAttack.SetIsCollider(false);
        _findEnemyToAttack.setIsFindEnemy(false);
    }

    public void IsFindEnemy()
    {
        Move(true);
        Idle(false);
    }
   
    public void SetCallBackCharacter(bool SetBool)
    {
        _isCallBack = SetBool;
    }

    public void SetMoveSpeed(float setSpeed)
    {
        _MoveSpeed = setSpeed;
    }

    public void IsReborn()
    {
        gameObject.transform.position = _CallBackPosition.transform.position;
        _CharHealth.charReborn();
        _CharHealth.setDead(false);
    }

#region Anim Function Manage

    public void AttackManagement(bool condition)
    {
        if(condition){
            //Debug.Log(_CatMuradAttack.getCountAttack());
            Move(false);
            if(_CatBoxerAttack.getCountAttack()<50)
            {
                Attack(true);
            }
            if(_CatBoxerAttack.getCountAttack() >= 10 && _CanSkill2)
            {
                _CanSkill2 = false;
                Attack2(true);
                Debug.Log("CallAt2");
                
            }
            if(_CatBoxerAttack.getCountAttack()>=50 && _CanSkill3)
            {
                
                ComboAttack(true);
                Debug.Log("CBAAA");
                // reset
                
                _CanSkill2 = true;
                _CanSkill3 = true;
            }
        }else
        {
            Attack(false);
            Attack2(false);

        }
    }
    public void Move(bool _isAttack)
    {
        _Anim.SetBool("Move",_isAttack);
    }

    public void Attack(bool _isAttack)
    {
        _Anim.SetBool("Attack",_isAttack);
    }

    public void Attack2(bool _isAttack)
    {
        //_Anim.Play("Attack2");
       _Anim.SetBool("Attack2",_isAttack);
    }

    public void ComboAttack(bool _isAttack)
    {
        _Anim.Play("ComboAttack");
        //_Anim.SetBool("ComboAttack",_isAttack);
    }

    public void Death(bool _isAttack)
    {
        _Anim.SetBool("Death",_isAttack);
    }

    public void Idle(bool condition)
    {
        _Anim.SetBool("Idle",condition);
    }
#endregion
    // Choose Object
   
   public void flipObject(GameObject Ob)
    {
        
        Vector2 scaleOb = transform.localScale;
        Vector2 scaleUI = _CanVasUI.transform.localScale;

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
        _CanVasUI.transform.localScale = scaleUI;
    }

#region Time Effect
    void BloodRestoneEffectTime()
    {
        _CountTime += Time.deltaTime;
        if(_CountTime >= 15)
        {
            _isBloodRestone = false;
            _CountTime = 0;
        }
    }
    #endregion

#region CharacterEffect

        public void BloodRestoneEffect(int _int)
        {
            if(_isBloodRestone)
                _CharHealth.addHealth(Mathf.Round((float) _int * _CharProperties.GetRateBlood()));
        }
    #endregion
    
}

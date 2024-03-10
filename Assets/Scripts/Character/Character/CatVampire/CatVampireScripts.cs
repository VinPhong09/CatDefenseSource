using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatVampireScripts : MonoBehaviour
{


    // Basic Variable
    [SerializeField] protected float _MoveSpeed ;
    [SerializeField] protected GameObject _CallBackPosition;

    [SerializeField] protected Slider _AttackEnergy;

    [SerializeField] protected Canvas _CanVasUI;

    bool _isCallBack = false;

    bool _isChoose = false;


    float _CurrenVelocity = 0,_CurrenValue = 0;

    bool _isflip ;

    //bool _isAttack = false;
    Vector2 _Target;
    Rigidbody2D _RG;
    public Animator _Anim;

    public Animation _Animation;

    CatVampireProperties _CharProperties;

    CatVampireFindEnemyToAttack _findEnemyToAttack;

    CatVampireAttack _CatVampireAttack;


    CharHealth _CharHealth;
    // Start is called before the first frame update
    void Start()
    {
        _RG = gameObject.GetComponent<Rigidbody2D>();
        _Anim = gameObject.GetComponent<Animator>();
        _findEnemyToAttack = gameObject.GetComponent<CatVampireFindEnemyToAttack>();
        _CatVampireAttack = gameObject.GetComponentInChildren<CatVampireAttack>();
        _CharProperties = gameObject.GetComponent<CatVampireProperties>();
        _CharHealth = gameObject.GetComponent<CharHealth>();
        _MoveSpeed = 1.5f;
        //
        _AttackEnergy.maxValue = 10;
        _AttackEnergy.minValue = 0;
        _AttackEnergy.value = 0;
    }

    void Update()
    {
        AttackEnergySlider();

        if(_CharHealth.getDead())
        {
            IsReborn();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       
        //if(!_isChoose)
            CallBackCharacter();
    }   

#region Check Detect Collider and Attack 
   /* private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" && other is BoxCollider2D && other.gameObject.name != "HitBoxE"){
            if(!_FirstCollider)
                {
                    _FirstCollider = true;
                    if(_CatMuradAttack.getCountAttack() == 3)
                    {
                        _Anim.Play("ComboAttack");
                        _CatMuradAttack.setCountAttack(0);
                    }
                    Attack(true);
                    _findEnemyToAttack.SetIsCollider(true);
                
                }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
       /* if(other.gameObject.tag == "Enemy" && other is BoxCollider2D && other.gameObject.name != "HitBoxE")
            {
                Attack(true);
            }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy" && other.gameObject.name != "HitBoxE")
            {
                _findEnemyToAttack.SetIsCollider(false);
                Move(true);
                Attack(false);
            }
    }*/
#endregion


    void CallBackCharacter()
    {
        if(Vector2.Distance(gameObject.transform.position, _CallBackPosition.transform.position ) < 0.1f)
        {
            _isCallBack = false;

             AttackManagement(false);

             Move(false); Idle(true);

             flipObject(gameObject);
        }
            
        if(_isCallBack)
        {
            //Move to target
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _CallBackPosition.transform.position, _MoveSpeed * Time.fixedDeltaTime);
            Debug.DrawLine(gameObject.transform.position, _CallBackPosition.transform.position);
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
        AttackManagement(false);
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
            Move(false);
            Idle(false);
            if(_CatVampireAttack.getCountAttack()<50 )
            {
                Attack(true);
            }
            if(_CatVampireAttack.getCountAttack() >= 10 )
            {
                BuffSkill(true);
                _CatVampireAttack.setCountAttack(0);
            }
            
        }else
        {
            Attack(false);
            BuffSkill(false);

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

    public void BuffSkill(bool _isAttack)
    {
        if(_isAttack)
            _Anim.Play("BuffSkill");
       //_Anim.SetBool("BuffSkill",_isAttack);
    }

    public void Idle(bool condition)
    {
        _Anim.SetBool("Idle",condition);
    }
#endregion
    // Choose Object
    public void ChooseObject()
    {
        _isChoose = true;
       
        Attack(false);
        transform.position = new Vector2 (transform.position.x,transform.position.y);
        Debug.Log(transform.position);
    }

    public bool getIschoose()
    {
        return _isChoose;
    }

    void ControllChar()
    {

        // Move By mouse
        if(Input.GetMouseButtonDown(1))
        {
            _Anim.SetBool("Run",true);
            _Target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Attack(false);


            //Flop
            if(_Target.x > gameObject.transform.position.x && gameObject.transform.localScale.x < 0 )
                gameObject.transform.localScale = new Vector2 (gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
            if(_Target.x < gameObject.transform.position.x && gameObject.transform.localScale.x > 0)
                gameObject.transform.localScale = new Vector2 (gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                

        }
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,_Target,_MoveSpeed *Time.deltaTime);


        // Check MoveTowards To has finished
        if(Vector2.Distance (gameObject.transform.position,_Target) <= 0.1f)
            _Anim.SetBool("Run",false);
        if(Vector2.Distance (gameObject.transform.position,_Target) >= 0.1f)
            Attack(false);   
    }

    void AttackEnergySlider()
    {
        // Smooth Slider
        _CurrenValue = Mathf.SmoothDamp(_AttackEnergy.value,_CatVampireAttack.getCountAttack(), ref _CurrenVelocity, 100*Time.deltaTime);
        _AttackEnergy.value = _CurrenValue;
    }
   
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
    

    #region CharacterEffect

    public void BloodRestoneEffect(int _int)
    {
        _CharHealth.addHealth(Mathf.Round((float) _int * _CharProperties.GetRateBlood()));
    }   


    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScritps : MonoBehaviour
{

    Character _CharacterScripts;
    EnemyScripts _ClosetE;
    public bool _isCollider = false;
    public bool _isFindEnemy = false;
    bool _isCallBack = false;
    
    public float _MoveSpeed;

    public float _CurrentExp;

    public float _ExpToUplevel;
    public int _Level;

    Canvas _CanVasUI;
    CharHealth _charHealth;
    // Start is called before the first frame update
    void Start()
    {
        //Get Component
        _CharacterScripts = this.gameObject.GetComponent<Character>();
        _charHealth = this.gameObject.GetComponent<CharHealth>();

        //Set begin variable
        _MoveSpeed = _CharacterScripts._MoveSpeed;
        _CanVasUI = _CharacterScripts._CanVasUI;
        _Level = _CharacterScripts._Level;
    }

    void Update(){
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(_charHealth.getHealthPlayer()<=0)
            return;
        FindClosetEnemy();   
    }

    

    void CallBackCharacter(GameObject _CallBackPosition)
    {
        if(Vector2.Distance(gameObject.transform.position,_CallBackPosition.transform.position) < 0.1f)
        {
            _isCallBack = false;

            //  AttackManagement(false);

            //  Move(false); Idle(true);

             flipObject(gameObject);
             
        }
            
        if(_isCallBack)
        {
            //Move to target
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,_CallBackPosition.transform.position , _MoveSpeed * Time.fixedDeltaTime);
            // Move(true);
            // AttackManagement(false);
            //Flop when Calling Back
            flipObject(_CallBackPosition);
        }
        
    }
    void FindClosetEnemy()
    {
            if(!_isFindEnemy)
            {
                _ClosetE = null;
                EnemyScripts [] _AllEnemy = GameObject.FindObjectsOfType<EnemyScripts>();
                foreach(EnemyScripts _CurrenEnemy in _AllEnemy)
                {
                    if(_CurrenEnemy.getIsChoose()== false)
                        _ClosetE = _CurrenEnemy;
                }
                if(_ClosetE != null)
                    _isFindEnemy = true;
                else
                    _isFindEnemy = false;
            }
            if(GameObject.FindObjectsOfType<EnemyScripts>().Length == 0 || _ClosetE == null)
                {
                    _isCallBack = true;
                    _isFindEnemy = false;
                    return;
                }
            if(_ClosetE != null)
            {
                
                    _ClosetE.setIsChoose(true);
                    flipObject(_ClosetE.gameObject);

                    _isCallBack = false;

                    if(_ClosetE.GetComponent<EnemyHealth>().getHealthEnemy() <= 0) // change target new
                    {
                        _isFindEnemy = false;  
                    }

                    if(!_isCollider)
                        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _ClosetE.transform.position,_MoveSpeed * Time.fixedDeltaTime);

                    if(Vector2.Distance(gameObject.transform.position,_ClosetE.transform.position) <= 0.07f)
                    {
                        // _CharacterScripts.AttackManagement(true);
                        _isCollider = true;
                    }

                    if(Vector2.Distance(gameObject.transform.position,_ClosetE.transform.position) >= 0.1f)
                    {
                        // _CharacterScripts.AttackManagement(false);
                        _isCollider = false;
                    }
            }
            
    }
    public void flipObject(GameObject Ob)
    {
        
        Vector2 scaleOb = transform.localScale;
        Vector2 scaleUI = _CanVasUI.transform.localScale;

        if(transform.position.x > Ob.transform.position.x)
        {

            scaleOb.x = Mathf.Abs(scaleOb.x) ; 
            scaleUI.x = Mathf.Abs(scaleUI.x) ;
        }
        else
        {
            scaleOb.x = Mathf.Abs(scaleOb.x) * -1;
            scaleUI.x = Mathf.Abs(scaleUI.x) * -1;
        }
        transform.localScale = scaleOb;
        _CanVasUI.transform.localScale = scaleUI;
    }

#region Properties Manage

    public void addExp(int exp)
    {
        _CurrentExp += exp;
        if(_CurrentExp >= _ExpToUplevel)
        {
            _CurrentExp = 0;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        int DamageRange = Random.Range(2,5);
        _ExpToUplevel += 50;
        _Level += 1;
        _CharacterScripts._Damage += _CharacterScripts._Damage;
        _charHealth.SetMaxHealth(100);
    }

    //Damage
#endregion
}
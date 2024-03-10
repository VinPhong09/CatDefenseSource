using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatVampireFindEnemyToAttack : MonoBehaviour
{

    CatVampireScripts _CharacterScripts;
    private bool _isCollider = false;
    [SerializeField] protected float _MoveSpeed; 

    EnemyScripts _ClosetE;
    bool _isFindEnemy = false;

    CharHealth _charHealth;
    void Start()
    {
        _CharacterScripts = gameObject.GetComponent<CatVampireScripts>();
        _charHealth = this.gameObject.GetComponent<CharHealth>();
    }
    void FixedUpdate()
    {
        if(_charHealth.getHealthPlayer()<=0)
                return;
        FindClosetEnemy();   
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
                    _CharacterScripts.SetCallBackCharacter(true);
                    _isFindEnemy = false;
                    return;
                }
            if(_ClosetE != null)
            {
                
                    _ClosetE.setIsChoose(true);
                    _CharacterScripts.flipObject(_ClosetE.gameObject);

                    _CharacterScripts.SetMoveSpeed(1.5f);
                    _CharacterScripts.IsFindEnemy();
                    _CharacterScripts.SetCallBackCharacter(false);

                    if(_ClosetE.GetComponent<EnemyHealth>().getHealthEnemy() <= 0) // change target new
                    {
                        _isFindEnemy = false;  
                    }

                    if(!_isCollider)
                        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, _ClosetE.transform.position,_MoveSpeed * Time.fixedDeltaTime);

                    if(Vector2.Distance(gameObject.transform.position,_ClosetE.transform.position) <= 0.07f)
                    {
                        _CharacterScripts.AttackManagement(true);
                        _isCollider = true;
                    }

                    if(Vector2.Distance(gameObject.transform.position,_ClosetE.transform.position) >= 0.1f)
                    {
                        _CharacterScripts.AttackManagement(false);
                        _isCollider = false;
                    }
                    
            }
            
    }

    public void SetIsCollider(bool SetBool)
    {
        _isCollider = SetBool;
    }

    public bool getIsFindEnemy()
    {
        return _isFindEnemy;
    }

    public void setIsFindEnemy(bool Cond)
    {
        _isFindEnemy = Cond;
    }
}

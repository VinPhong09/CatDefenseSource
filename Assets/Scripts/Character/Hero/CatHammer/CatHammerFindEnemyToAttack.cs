using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CatHammerFindEnemyToAttack : MonoBehaviour
{

    CatHammerScripts _CharacterScripts;
    bool _isFlop = false;
    private bool _isCollider = false;
    [SerializeField] protected float _MoveSpeed; 




    void Start()
    {
        _CharacterScripts = gameObject.GetComponent<CatHammerScripts>();
    }
    void FixedUpdate()
    {
        if(!_isCollider)
            FindClosetEnemy();    
        else
            return;
    }

    void FindClosetEnemy()
    {
        if(!_CharacterScripts.getIschoose())
        {
            float _DistanceToClosetEnemy = Mathf.Infinity;
            EnemyScripts _ClosetEnemy = null;
            EnemyScripts [] _AllEnemy = GameObject.FindObjectsOfType<EnemyScripts>();

            foreach(EnemyScripts _CurrenEnemy in _AllEnemy)
            {
                float _distanceToEnemy = (_CurrenEnemy.transform.position - this.transform.position).sqrMagnitude;
                if(_distanceToEnemy < _DistanceToClosetEnemy)
                {
                    _DistanceToClosetEnemy = _distanceToEnemy;
                    _ClosetEnemy = _CurrenEnemy;
                }
            }
            if(_ClosetEnemy != null)
            {
                
                // Flop
                Flop(_ClosetEnemy);

                _CharacterScripts.SetMoveSpeed(1.5f);
                _CharacterScripts.IsFindEnemy();
                _CharacterScripts.SetCallBackCharacter(false);
                if(_ClosetEnemy.GetComponent<EnemyHealth>().getHealthEnemy() <= 0)
                    return;
                gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, new Vector2 (_ClosetEnemy.transform.position.x - 0.5f ,_ClosetEnemy.transform.position.y ),_MoveSpeed * Time.fixedDeltaTime);
            }
            if(GameObject.FindObjectsOfType<EnemyScripts>().Length == 0 )
                {
                    _CharacterScripts.SetCallBackCharacter(true);
                }
        }
    }

    public void SetIsFlop(bool SetIsFlop)
    {
        _isFlop = SetIsFlop;
    }

    void Flop(EnemyScripts enemy)
    {
            if(enemy.transform.position.x > gameObject.transform.position.x  && _isFlop)
            {  
                _isFlop = false;
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
            }
            if(enemy.transform.position.x < gameObject.transform.position.x && !_isFlop)
            {
                _isFlop = true;
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
            }
    }

    public void SetIsCollider(bool SetBool)
    {
        _isCollider = SetBool;
    }
}

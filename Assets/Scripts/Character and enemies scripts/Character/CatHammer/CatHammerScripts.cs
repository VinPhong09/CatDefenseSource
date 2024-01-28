using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatHammerScripts : MonoBehaviour
{

    public GameObject selectedObject;
  

    // Basic Variable
    [SerializeField] protected float _MoveSpeed ;
    [SerializeField] protected GameObject _CallBackPosition;

    bool _isCallBack = false;

    bool _isChoose = false;

    //bool _Attackenemy = false;

    //bool _isAttack = false;
    Vector2 _Target;
    Rigidbody2D _RG;
    Animator _Anim;

    CatHammerFindEnemyToAttack _findEnemyToAttack;


    // Start is called before the first frame update
    void Start()
    {
        _RG = gameObject.GetComponent<Rigidbody2D>();
        _Anim = gameObject.GetComponent<Animator>();
        _CallBackPosition = GameObject.FindGameObjectWithTag("CallBack");
        _findEnemyToAttack = gameObject.GetComponent<CatHammerFindEnemyToAttack>();

    }

    void Update()
    {
        
        /*if(_isChoose)
            ControllChar();*/

    }
    // Update is called once per frame
    void FixedUpdate()
    {
       // OnmouseCheck();
        if(!_isChoose)
            CallBackCharacter();
    }   

#region Check Detect Collider
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy" && other is BoxCollider2D)
            {
                Attack(true);
                _findEnemyToAttack.SetIsCollider(true);
            }
        /*if(other.gameObject.tag == "CallBack" && !_isChoose)
        {
            _MoveSpeed = 0;
            Attack(false);
            _Anim.SetBool("Run",false);
            _findEnemyToAttack.SetIsFlop(false);
        }*/
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy" && other is BoxCollider2D)
            {
                Attack(true);
            }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy" && other is BoxCollider2D)
            {
                //Attack(false);
            }
    }
#endregion


    void CallBackCharacter()
    {
        if(Vector2.Distance(gameObject.transform.position,_CallBackPosition.transform.position) < 0.1f)
        {
            _isCallBack = false;
            Attack(false);
            _Anim.SetBool("Run",false);
            _findEnemyToAttack.SetIsFlop(false);
        }
        if(_isCallBack)
        {
            //Move to target
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,_CallBackPosition.transform.position, _MoveSpeed * Time.fixedDeltaTime);
            Debug.DrawLine(gameObject.transform.position, _CallBackPosition.transform.position );
            _findEnemyToAttack.SetIsFlop(true);

            //Flop when Calling Back
            if(gameObject.transform.localScale.x > 0)
                gameObject.transform.localScale = new Vector2 (gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
        }
        
    }
    public void isKillerEnemy()
    {
        Attack(false);
        _Anim.SetBool("AB",false);
        _findEnemyToAttack.SetIsCollider(false);
    }

    public void IsFindEnemy()
    {
        _Anim.SetBool("Run",true);
    }
    public void SetCallBackCharacter(bool SetBool)
    {
        _isCallBack = SetBool;
    }

    public void SetMoveSpeed(float setSpeed)
    {
        _MoveSpeed = setSpeed;
    }

    public void Attack(bool _isAttack)
    {
        _Anim.SetBool("AB",_isAttack);
    }

    // Choose Object
    public void ChooseObject()
    {
        _isChoose = true;
       
        Attack(false);
        transform.position = new Vector2 (transform.position.x,transform.position.y);
        Debug.Log("Choose");
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


    /*void OnmouseCheck()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            
            if (targetObject)
            {
                Debug.Log(targetObject.transform.name);
                _Attackenemy = true;
            }
        }   
        if(_Attackenemy)
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position,targetObject.transform.position, 1.5f *Time.deltaTime);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScripts : MonoBehaviour
{
    Rigidbody2D _RG;
    Animator _Anim;

    AudioSource _audio;

    //Move Variable
   [SerializeField]protected float MoveSpeed = 1.2f;

   bool _isAttack = false;

   private bool _isChoose = false;


    private void Start()
    {
       _RG = gameObject.GetComponent<Rigidbody2D>();
       _Anim = gameObject.GetComponent<Animator>();
       _audio = GetComponent<AudioSource>();
       
    }

   void Update()
   { 
   }
    private void FixedUpdate()
    {
        AutoMove();
    }
    void AutoMove()
    {
      if(!_isAttack)
      {
         _RG.MovePosition(gameObject.transform.position - gameObject.transform.right * MoveSpeed * Time.fixedDeltaTime);
      }
      else
         return;
         
    }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag == "Character" && other is CapsuleCollider2D)
       {
         _isAttack = true;
         _Anim.SetBool("AT", true);
       }
       if(other.gameObject.tag == "Tower")
         {
            _isAttack = true;
            _Anim.SetBool("AT", true);
         }
   }
   void OnTriggerStay2D(Collider2D other)
   {
       if(other.gameObject.tag == "Character" && other is CapsuleCollider2D)
       {
         _isAttack = true;
         _Anim.SetBool("AT", true);
       }
       if(other.gameObject.tag == "Tower")
         {
            _isAttack = true;
            _Anim.SetBool("AT", true);
         }
   }
   void OnTriggerExit2D(Collider2D other)
   {
       if(other.gameObject.tag == "Character" && other is CapsuleCollider2D)
       {
         if(Vector2.Distance(this.gameObject.transform.position,other.gameObject.transform.position) >=1)
         {
            _isAttack = false;
            _Anim.SetBool("AT", false);
         }
       }
   }
   
   
   
   public void isKillerCharacter()
   {
      _isAttack = false;
      _Anim.SetBool("AT",false);
   }

   public void IsDead()
   {
      _Anim.SetBool("Die",true);
      _audio.Play();
      _RG.constraints = RigidbodyConstraints2D.FreezeAll;
   }

   public bool getIsChoose()
   {
      return _isChoose;
   }

   public void setIsChoose(bool condition)
   {
      _isChoose = condition;
   }
}

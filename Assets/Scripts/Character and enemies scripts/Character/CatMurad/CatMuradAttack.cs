using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMuradAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    CatMuradScripts _CharScripts;
    CatMuradProperties _CharProperties;

    Animator _Anim;

    AudioSource _audio;

    static int _countAttack = 0;
    void Start()
    {
        _CharScripts = gameObject.GetComponentInParent<CatMuradScripts>();
        _CharProperties = GetComponentInParent<CatMuradProperties>();
        _Anim = GetComponentInParent<Animator>();
        _audio = GetComponentInParent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyHealth _Ehealth = other.gameObject.GetComponent<EnemyHealth>();
            if(other is CapsuleCollider2D)
            {
                int _CurrentDamage1 = (int)_CharProperties.GetDamageSkill1();
                int _CurrentDamage = (int)_CharProperties.GetDamage() * 2;
                int _CurrentDamage2 = (int)_CharProperties.GetDamageSkill2();
                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") ) // get name Anim
                {
                    _countAttack +=2; 
                    _Ehealth.addDamage(_CurrentDamage1,null); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage1);
                    _audio.Play();
                }

                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2") ) // get name Anim
                {
                    _countAttack +=5; 
                    _Ehealth.addDamage(_CurrentDamage,"Crit"); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage);
                     _audio.Play();
                }

                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("ComboAttack")) // get name Anim
                {
                    _Ehealth.addDamage(_CurrentDamage2,null); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage2);
                    _audio.Play();
                }

            }

           
             if(_Ehealth.getHealthEnemy()<= 0)
                   Invoke("IsDead",0.1f);
        }
    }

      void IsDead()
    {
       _CharProperties.addExp(10);
    }

    public int getCountAttack()
    {
        return _countAttack;
    }

    public void setCountAttack(int countAttack)
    {
        _countAttack = countAttack;
    }

   
}

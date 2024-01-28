using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFoloAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    CatFoloScripts _CharScripts;
    CatFoloProperties _CharProperties;

    Animator _Anim;

    AudioSource _audio1;
    static int _countAttack = 0;
    void Start()
    {
        _CharScripts = gameObject.GetComponentInParent<CatFoloScripts>();
        _CharProperties = GetComponentInParent<CatFoloProperties>();
        _Anim = GetComponentInParent<Animator>();
        _audio1 = GetComponentInParent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyHealth _Ehealth = other.gameObject.GetComponent<EnemyHealth>();


            if(other is CapsuleCollider2D)
            { 
                int _CurrentDamage1 = (int)_CharProperties.GetDamageSkill1();
                int _CurrentDamage = (int)_CharProperties.GetDamage();
                int _CurrentDamage2 = (int)_CharProperties.GetDamageSkill2();
                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) // get name Anim
                { 
                    _Ehealth.addDamage(_CurrentDamage1,null); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage1);
                    _audio1.Play();
                }

                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2")) // get name Anim
                {
                    _Ehealth.addDamage(_CurrentDamage,null); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage);
                    _audio1.Play();
                }

                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("ComboAttack")) // get name Anim
                {
                    _Ehealth.addDamage(_CurrentDamage2,null); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage2);
                    _audio1.Play();
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
        return Random.Range(0,6);
    }

    public void setCountAttack(int countAttack)
    {
        _countAttack = countAttack;
    }
}

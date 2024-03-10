using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBoxerAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    CatBoxerScripts _CharScripts;
    CatBoxerProperties _CharProperties;

    Animator _Anim;

    public AudioClip _aud1;
    public AudioClip _aud2;

    AudioSource _audioS;

    void Start()
    {
        _CharScripts = gameObject.GetComponentInParent<CatBoxerScripts>();
        _CharProperties = GetComponentInParent<CatBoxerProperties>();
        _Anim = GetComponentInParent<Animator>();
        _audioS = GetComponentInParent<AudioSource>();

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
                    _audioS.PlayOneShot(_aud1);
                }

                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2")) // get name Anim
                {
                    _Ehealth.addDamage(_CurrentDamage,null);
                    _CharScripts.BloodRestoneEffect(_CurrentDamage);
                    _audioS.PlayOneShot(_aud1);
                }

                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("ComboAttack")) // get name Anim
                {
                    _Ehealth.addDamage(_CurrentDamage2,null); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage2);
                    _audioS.PlayOneShot(_aud2);
                }

            }


            if(_Ehealth.getHealthEnemy()<= 0)
                   Invoke("IsDead",0.1f);
        }
    }

      void IsDead()
    {
       _CharProperties.addExp(5);
    }

    public int getCountAttack()
    {
        return Random.Range(0,5);
    }

}

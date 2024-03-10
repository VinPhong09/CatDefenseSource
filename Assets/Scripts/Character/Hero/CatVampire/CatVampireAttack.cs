using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatVampireAttack : MonoBehaviour
{
    // Start is called before the first frame update
    
    CatVampireScripts _CharScripts;
    CatVampireProperties _CharProperties;

    Animator _Anim;

    AudioSource _audio;

     int _countAttack = 0;
    void Start()
    {
        _CharScripts = gameObject.GetComponentInParent<CatVampireScripts>();
        _CharProperties = GetComponentInParent<CatVampireProperties>();
        _Anim = GetComponentInParent<Animator>();
        _audio = GetComponentInParent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyHealth _Ehealth = other.gameObject.GetComponent<EnemyHealth>();


            if(other is CapsuleCollider2D)
            {
                 int _CurrentDamage = (int)_CharProperties.GetDamage();
                if(_Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) // get name Anim
                {
                    _countAttack +=1; 
                    _Ehealth.addDamage(_CurrentDamage,null); 
                    _CharScripts.BloodRestoneEffect(_CurrentDamage);
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

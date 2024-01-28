using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBrexAnim : MonoBehaviour
{
    // Start is called before the first frame updatepublic Animator animator;
    Character _Character;
    CharacterScritps _CharacterScripts;
    CharHealth _CharHealth;
    Animator _animator;
    CatBrexAttack _CatbrexAttack;

    [Header("Audio")]
    public AudioClip _aud1;
    public AudioClip _aud2;
    AudioSource _AudioS;

    void Start()
    {
        _Character = this.gameObject.GetComponent<Character>();
        _CharacterScripts = this.gameObject.GetComponent<CharacterScritps>();
        _CharHealth = this.gameObject.GetComponent<CharHealth>();
        _animator = this.gameObject.GetComponent<Animator>();
        _CatbrexAttack = this.gameObject.GetComponent<CatBrexAttack>();
        _AudioS = GetComponentInParent<AudioSource>();

       
        // Phương thức sẽ được gọi khi event được kích hoạt
    }

    // Phương thức được gọi khi event được kích hoạt

#region Attack Damage Function
    public void PunchSkill1()
    {
        _CatbrexAttack.setCurrentDamage(_Character._Damage,_Character._Skills[0]._DamagePercentage);
        _AudioS.PlayOneShot(_aud1);
    }

    public void PunchSkill2()
    {
        _CatbrexAttack.setCurrentDamage(_Character._Damage,_Character._Skills[0]._DamagePercentage);
        _AudioS.PlayOneShot(_aud2);
    }

    public void PowerUpSkill()
    {

    }


#endregion


#region Animation Function 

    public void Idle(bool _Bool)
    {
        _animator.SetBool("Idle",_Bool);
    }
    public void Walk(bool _Bool)
    {
        _animator.SetBool("Walk",_Bool);
    }

     public void Run(bool _Bool)
    {
        _animator.SetBool("Run",_Bool);
    }
    public void PunchSkill1(bool _Bool)
    {
        _animator.SetBool("PunchSkill1",_Bool);
    }
    public void PunchSkill2(bool _Bool)
    {
        _animator.SetBool("PunchSkill2",_Bool);
    }

    public void PowerUpSkill(bool _Bool)
    {
        _animator.SetBool("PowerUpSkill",_Bool);
    }

#endregion

#region Animation Manager

    public void _isMove()
    {
        if(_CharacterScripts._isFindEnemy)
        {
            Run(true);
            Idle(false);
        }
    }

#endregion


    void Update()
    {
        _isMove();
    }
}

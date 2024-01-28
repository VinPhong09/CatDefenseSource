using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBrexAttack : MonoBehaviour
{
    Character _character;
    CharacterScritps _CharacterScripts;

    [Header("Audio")]
    public AudioClip _aud1;
    public AudioClip _aud2;
    AudioSource _AudioS;

    float _CurrentDamage;
    // Start is called before the first frame update
    void Start()
    {
        _character = this.gameObject.GetComponent<Character>();
        _CharacterScripts = this.gameObject.GetComponent<CharacterScritps>();
        _AudioS = this.gameObject.GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyHealth _Ehealth = other.gameObject.GetComponent<EnemyHealth>();

            _Ehealth.addDamage((int)_CurrentDamage,null);

            if(_Ehealth.getHealthEnemy()<= 0)
                Invoke("IsDead",0.1f);
        }
    }

    void IsDead()
    {
       _CharacterScripts.addExp(5);
    }

    public float GetCurrentDamage()
    {
        return (int)_CurrentDamage;
    }

    public void setCurrentDamage(float _Damage, float PercentDamage)
    {
        _CurrentDamage = _Damage * PercentDamage;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    //[SerializeField] protected float _Damage;
    // Start is called before the first frame update
    CatHammerScripts _CharScripts;
    CatHammerProperties _CharProperties;
    void Start()
    {
        _CharScripts = gameObject.GetComponentInParent<CatHammerScripts>();
        _CharProperties = GetComponentInParent<CatHammerProperties>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            EnemyHealth _Ehealth = other.gameObject.GetComponent<EnemyHealth>();
            if(other is CapsuleCollider2D)
                _Ehealth.addDamage(_CharProperties.GetDamage(),null);               
            if(_Ehealth.getHealthEnemy()<= 0)
                   Invoke("IsDead",0.1f);   
        }
    }

    void IsDead()
    {
        _CharScripts.isKillerEnemy();
    }
}

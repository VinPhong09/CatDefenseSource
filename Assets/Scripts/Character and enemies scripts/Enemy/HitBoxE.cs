using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxE : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected float _Damage;

    EnemyScripts _EnemyScripts;
    void Start()
    {
        _EnemyScripts =gameObject.GetComponentInParent<EnemyScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Character")
        {
            CharHealth _Chealth= other.gameObject.GetComponent<CharHealth>();
            if(other is CapsuleCollider2D)
               _Chealth.addDamage(_Damage);
            if(_Chealth.getHealthPlayer() <= 0)
                Invoke("IsDead",0);
                
        }
        if(other.gameObject.tag == "Tower")
         {
            TowerScripts _TowerHealth = other.gameObject.GetComponent<TowerScripts>();
            _TowerHealth.addDamage(_Damage);
         }
    }

    public void setDamageEnemy(float _Damage)
    {
        this._Damage += _Damage;
    }
    
    public void IsDead()
    {
        _EnemyScripts.isKillerCharacter();
        _EnemyScripts.setIsChoose(false);
    }
    
}

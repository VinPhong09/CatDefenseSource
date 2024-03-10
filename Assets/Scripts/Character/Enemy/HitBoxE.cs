using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxE : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected int _Damage;

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
        if(other.gameObject.CompareTag("Character"))
        {
            IHealth iHealth = other.gameObject.GetComponent<IHealth>();
            if (other is CapsuleCollider2D)
            {
                iHealth.TakeDamage(_Damage);
            } 
        }
        if(other.gameObject.CompareTag("Tower"))
         {
            TowerScripts towerHealth = other.gameObject.GetComponent<TowerScripts>();
            towerHealth.addDamage(_Damage);
         }
    }

    public void setDamageEnemy(int _Damage)
    {
        this._Damage += _Damage;
    }
    
    public void IsDead()
    {
        _EnemyScripts.isKillerCharacter();
        _EnemyScripts.setIsChoose(false);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatHammerProperties : MonoBehaviour
{

    int _Damage, _DamageMin, _DamageMax;

    //Get Component
    CatHammerScripts _CharScripts;



    // Start is called before the first frame update
    void Start()
    {

        //Set Begin Damage
        _DamageMax = 12;
        _DamageMin = 8;

        //Get Component
        _CharScripts = this.gameObject.GetComponent<CatHammerScripts>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public int GetDamage()
    {
        return Random.Range(_DamageMin,_DamageMax);
    }
}

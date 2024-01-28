using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterEffect : MonoBehaviour
{
    CharHealth _CharHealth;
    Rigidbody2D _RG;
    void Start()
    {
        _RG = gameObject.GetComponent<Rigidbody2D>();
        _CharHealth = gameObject.GetComponent<CharHealth>();
        //
    }

    
    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.tag == "BloodRestone" )
    //     {
    //         CatVampireProperties catVPPrope = other.gameObject.GetComponentInParent<CatVampireProperties>();
    //         _CharProperties.StartCoroutineEffect(catVPPrope.GetRateBloodEffect());
    //         _isBloodRestone = true; 
    //     }
    // }
}
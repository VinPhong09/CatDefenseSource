using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagementScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterManager _charMNG;
    AudioSource _audio;
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

     private void Start()
     {
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = 60;
        //  testchar();
        
     }

    // Update is called once per frame
    void Update()
    {
        
    }

    void testchar()
    {
        
            Debug.Log("CN: "+_charMNG.allCharacters[0]._Name);
            Debug.Log("Des: " + _charMNG.allCharacters[0]._Description);
            foreach(Skill sk in _charMNG.allCharacters[0]._Skills)
            {
                Debug.Log("Skill: " + sk._Name);
               
            }
    }
}

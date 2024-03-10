using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    public CharacterManager characterManager;
    AudioSource _audio;
    
    protected override void Awake()
    {
        base.Awake();
        characterManager = GetComponentInChildren<CharacterManager>();
        _audio = GetComponent<AudioSource>();
        _audio.Play();
    }

     private void Start()
     {
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = 60;
        
         characterManager.Initialize();
         characterManager.CreateCharacter();
        
     }

    // Update is called once per frame
    void Update()
    {
        characterManager.Handle();
    }

    
}

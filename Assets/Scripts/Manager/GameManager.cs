using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CharacterManager characterManager;
    AudioSource _audio;

    private bool isInitCharacter = true;
    protected override void Awake()
    {
        base.Awake();
        characterManager = GetComponentInChildren<CharacterManager>();
        _audio = GetComponent<AudioSource>();
        _audio.Play();
        DontDestroyOnLoad(this);
    }

     private void Start()
     {
         characterManager.Initialize();
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = 60;
     }

     public void initCharacter()
     {
         
         characterManager.CreateCharacter();
         isInitCharacter = true;
     }
    // Update is called once per frame
    void Update()
    {
        if(isInitCharacter)
            characterManager.Handle();
    }

    
}

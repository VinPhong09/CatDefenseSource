using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    AudioSource _audio;
    private CharacterManager _characterManager;
    private PoolManager _poolManager;
    private bool _startGame = false;
    protected override void Awake()
    {
        base.Awake();
        _audio = GetComponent<AudioSource>();
        _audio.Play();
        DontDestroyOnLoad(this);
    }

     private void Start()
     {
         _characterManager = CharacterManager.Instance;
         _poolManager = PoolManager.Instance;
         
         //Initialize Component
         _characterManager.Initialize();
         
         QualitySettings.vSyncCount = 0;
         Application.targetFrameRate = 60;
     }

     public void StartGame()
     {
         initCharacter();
         _startGame = true;
     }
     public void initCharacter()
     {
         _characterManager.CreateCharacter();
       
         _poolManager.Initialize();
         _poolManager.OnPoolEnable();
     }
    // Update is called once per frame
    void Update()
    {
        if (_startGame)
        {
            _characterManager.Handle();
            _poolManager.Handle();
        }
    }

    void OnNextGameLevel()
    {
        PoolManager.Instance.OnPoolEnable();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData 
{
    public AudioClip AudioClip;
    public AudioSoundType AudioSoundType;
}

public enum AudioSoundType
{
    //Character
   Attack,
   Skill,
   Die,
   //UI
   ButtonClick,
   //
   BackGround,
}
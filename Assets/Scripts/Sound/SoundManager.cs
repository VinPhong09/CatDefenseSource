using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [Header("CHARACTER")]
    public List<CharacterSound> CharacterSounds;
    [Header("VFXSounds")]
    public List<SoundData> VFXSounds;
    [Header("ThemeSounds")]
    public List<SoundData> ThemeSounds;
}

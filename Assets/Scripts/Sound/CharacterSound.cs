using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;

[System.Serializable]
public class CharacterSound 
{
   public string characterName;
   public CharacterType characterType;
   public List<SoundData> soundDatas;
   public AudioSource audioSource;

   public CharacterSound()
   {
      audioSource = new AudioSource();
   }
}

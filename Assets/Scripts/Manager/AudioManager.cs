using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
   private AudioSource _audioSource;
   public AudioSource CharacterAudioSource;
   public AudioSource SFXAudioSource;
   public AudioSource ThemeAudioSource;
   public void Start()
   {
      _audioSource = this.gameObject.GetComponent<AudioSource>();
      _audioSource.Play();
   }

   public void OnCharacterPlaySound(AudioClip audioClip)
   {
      _audioSource.PlayOneShot(audioClip);
   }
   
   public void OnSFXPlaySound(AudioClip audioClip)
   {
      _audioSource.PlayOneShot(audioClip);
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager1 : MonoBehaviour
{
   [Header("----- Audio Source -----")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   [Header("----- Audio Clip -----")]
   public AudioClip background;
   public AudioClip arrasta;

   private void Start()
   {
    musicSource.clip = background;
    musicSource.Play();
      
   }


}

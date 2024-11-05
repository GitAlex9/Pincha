using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [Header("---------- Audio Source ----------")]
   [SerializeField] AudioSource musicSource;
   [SerializeField] AudioSource SFXSource;

   [Header("---------- Audio Clip ----------")]
   public AudioClip background;
   public AudioClip arrasta;
   public AudioClip win;
   public AudioClip death;

   private bool isGamePaused = false;

   private void Start()
   {
    musicSource.clip = background;
    musicSource.Play();
   }

    public void PauseBackgroundMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Pause();
            isGamePaused = true;
        }
    }

    public void ResumeBackgroundMusic()
    {
        if (isGamePaused && musicSource.clip != null)
        {
            musicSource.Play();
            isGamePaused = false;
        }
    }

}

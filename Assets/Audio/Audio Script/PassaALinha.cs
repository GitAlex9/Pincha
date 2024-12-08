using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassaALinha : MonoBehaviour
{

    public static PassaALinha instance; 

    public AudioSource audioSource;

    public AudioClip crossingSound;

     private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
       

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
   
     public void PlaySound()
    {
        audioSource.PlayOneShot(crossingSound);
    }

}

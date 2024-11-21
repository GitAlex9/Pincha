// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlaySoundOnEnter : MonoBehaviour
// {

//     AudioManager audioManager;

//     BoxCollider soundTrigger;

//     void Awake()
//     {
//         audioManager = GetComponent<AudioManager>();

//         soundTrigger = GetComponent<BoxCollider>();
//     }

//     void OnTriggerEnter(Collider other)
//     {
//         if(other.gameObject.tag == "Player")
//         audioManager.PlaySFX(audioManager.win);
//         audioManager.PauseBackgroundMusic();
        
//     }


   
// }

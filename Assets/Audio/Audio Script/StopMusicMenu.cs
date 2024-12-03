using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopMusicMenu : MonoBehaviour
{


   
    void Update()
    {
          if (SceneManager.GetActiveScene().name == "MainMenu")
          {
            
            AudioManager.instance.GetComponent<AudioSource>().Pause();
            
          }
          
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip background;
 
    void Awake()
    {
        if (instance != null)
            // Destroy(gameObject);
            AudioManager.instance.GetComponent<AudioSource>().Pause();

        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
           

            
        }
    }

}

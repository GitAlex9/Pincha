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

//    public GameObject telaVitoria;

    
   private void Start()
   {
    musicSource.clip = background;
    musicSource.Play();
   }

   public void PlaySFX(AudioClip clip)
   {
    SFXSource.PlayOneShot(clip);
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

  

   

//   public void vitoria()
//   {
//     if(telaVitoria == true)
//     {
//         SFXSource.Pause();
//     }
//   }

}

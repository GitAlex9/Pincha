using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{

     public static VolumeSetting instance;

   [SerializeField] private AudioMixer myMixer;
   [SerializeField] public Slider musicSlider;
   [SerializeField] public Slider SFXSlider;

   // private const float MAX_VOLUME = 1f;


   private void Start()
   {

        instance = this;
        
     if(PlayerPrefs.HasKey("musicVolume"))
     {
        LoadVolume();
     }
     else
     {
        SetMusicVolume();
        SetSFXVolume();
     }
   }

   public void SetMusicVolume()
   {
      float volume = musicSlider.value;
      myMixer.SetFloat("music", Mathf.Log10(volume)*20);
      PlayerPrefs.SetFloat("musicVolume", volume);
   }

    public void SetSFXVolume()
   {
      float volume = SFXSlider.value;
      myMixer.SetFloat("SFX", Mathf.Log10(volume)*20);
      PlayerPrefs.SetFloat("SFXVolume", volume);
   }

    

   private void LoadVolume()
   {
    musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

    SetMusicVolume();
    SetSFXVolume();

   }
}
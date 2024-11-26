using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundButtonManager : MonoBehaviour
{
[SerializeField] private AudioMixer myMixer;

[SerializeField] Image soundOnIcon;
[SerializeField] Image soundOffIcon;
[SerializeField] Image sfxOnIcon;
[SerializeField] Image sfxOffIcon;

[SerializeField] AudioMixerGroup musicMixerGroup;
[SerializeField] AudioMixerGroup sfxMixerGroup;

private VolumeSetting volumeSetting;

[SerializeField] private Slider musicSlider;
[SerializeField] private Slider sfxSlider;

private bool isMusicMuted = false;
private bool isSfxMuted = false;

void Start()
{

    if(!PlayerPrefs.HasKey("IsMusicMuted"))
   {

      PlayerPrefs.SetInt("IsMusicMuted", 0);
      PlayerPrefs.SetInt("IsSfxMuted", 0);
      Load();
    
   }
   else
   {
    //   Load();
   }
    
    UpdateMusicButtonIcon();
    UpdateSfxButtonIcon();

}

  public void OnMusicMuteButtonPressed()
    {
        isMusicMuted = !isMusicMuted;
        float volume = musicSlider.value;
        musicMixerGroup.audioMixer.SetFloat("music",isMusicMuted ? -80f : Mathf.Log10(volume)*20); 
        UpdateMusicButtonIcon();
    }

    public void OnSfxMuteButtonPressed()
    {
        isSfxMuted = !isSfxMuted;
        float volume = sfxSlider.value;
        sfxMixerGroup.audioMixer.SetFloat("SFX", isSfxMuted ? -80f : Mathf.Log10(volume)*20); 
        UpdateSfxButtonIcon();
    }

private void UpdateMusicButtonIcon()
{

 if(isMusicMuted == false)
 {

  soundOnIcon.enabled = true;
  soundOffIcon.enabled = false;

 }
else
{

  soundOnIcon.enabled = false;
  soundOffIcon.enabled = true;

 }
}

private void UpdateSfxButtonIcon()
{

 if(isSfxMuted == false)
 {

  sfxOnIcon.enabled = true;
  sfxOffIcon.enabled = false;

 }
else
{

  sfxOnIcon.enabled = false;
  sfxOffIcon.enabled = true;

 }

}

private void Load()
{

  isMusicMuted = PlayerPrefs.GetInt("IsMusicMuted", 0) == -80; 
  isSfxMuted = PlayerPrefs.GetInt("IsSfxMuted", 0) == -80; 

}

}



 
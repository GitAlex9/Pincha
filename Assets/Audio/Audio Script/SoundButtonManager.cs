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
        musicMixerGroup.audioMixer.SetFloat("music", isMusicMuted ? -80f : 0f); 
        // SaveMusicMuted();
        UpdateMusicButtonIcon();
        // PlayerPrefs.SetInt("IsMusicMuted", isMusicMuted ? 1 : 0);
        Save();
    }

    public void OnSfxMuteButtonPressed()
    {
        isSfxMuted = !isSfxMuted;
        sfxMixerGroup.audioMixer.SetFloat("SFX", isSfxMuted ? -80f : 0f); 
        // SaveSfxMuted();
        UpdateSfxButtonIcon();
        Save();
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

isMusicMuted = PlayerPrefs.GetInt("IsMusicMuted", 0) == 1; 
isSfxMuted = PlayerPrefs.GetInt("IsSfxMuted", 0) == 1; 

//  if (VolumeSetting.instance != null) // Check for VolumeSetting script
//         {
//             VolumeSetting.instance.SetMusicVolume(isMusicMuted ? 0f : PlayerPrefs.GetFloat("musicVolume", 1f)); // 1f for default max volume
//             VolumeSetting.instance.SetSFXVolume(isSfxMuted ? 0f : PlayerPrefs.GetFloat("SFXVolume", 1f));
//         }

}

private void Save()
{

    PlayerPrefs.SetInt("IsMusicMuted", isMusicMuted ? 1 : 0);
    PlayerPrefs.SetInt("IsSfxMuted", isSfxMuted ? 1 : 0);

}

 }
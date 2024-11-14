using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

[SerializeField] Image soundOnIcon;
[SerializeField] Image soundOffIcon;

public bool isMuted = false;

// public Sprite mutedSprite;
// public Sprite unmutedSprite;

public AudioSource musicSource;
public Button muteButton;

void Start()
{
    // ... (código anterior)

    if (!PlayerPrefs.HasKey("isMuted"))
    {
        PlayerPrefs.SetInt("isMuted", 0);
    }
    else
    {
        isMuted = PlayerPrefs.GetInt("isMuted") == 1;
        musicSource.mute = isMuted;
    }
}


public void MuteMusic()
{
     musicSource.mute = !musicSource.mute;

     isMuted = !isMuted;
    musicSource.mute = isMuted;
    PlayerPrefs.SetInt("isMuted", isMuted ? 1 : 0);
     muteButton.image = isMuted ? soundOffIcon : soundOnIcon;
}

}
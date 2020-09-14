using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button audioButton;
    public static Sprite enableVolumeSprite;
    public static Sprite disableVolumeSprite;

    AudioSource audio;
    bool isMusicActive = true;
    
    void Start()
    {
        audio = FindObjectOfType<AudioSource>();
        DontDestroyOnLoad(audio);
        DontDestroyOnLoad(audioButton);

        print("ScriptLoaded");
        print(isMusicActive);

        if (isMusicActive)
        {
            audio.mute = false;
            isMusicActive = true;
            audioButton.image.sprite = enableVolumeSprite;
        }
        else
        {
            audio.mute = true;
            isMusicActive = false;
            audioButton.image.sprite = disableVolumeSprite;
        }
    }

    public void MuteAudio()
    {
        if (isMusicActive)
        {
            audio.mute = true;
            isMusicActive = !isMusicActive;
            audioButton.image.sprite = disableVolumeSprite;
        }
        else
        {
            audio.mute = false;
            isMusicActive = !isMusicActive;
            audioButton.image.sprite = enableVolumeSprite;
        }
    }
}

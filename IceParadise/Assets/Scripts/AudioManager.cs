using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Button audioButton;
    public Sprite enableVolumeSprite;
    public Sprite disableVolumeSprite;

    AudioSource audio;
    bool isMusicActive = true;
    
    void Start()
    {
        audio = FindObjectOfType<AudioSource>();
        DontDestroyOnLoad(audio);
        DontDestroyOnLoad(audioButton);
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

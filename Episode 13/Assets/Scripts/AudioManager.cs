using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audio;
    public Button audioButton;
    public Sprite enableVolume;
    public Sprite disableVolume;

    bool isMusicActive = true;
    
    void Start()
    {
        audio = FindObjectOfType<AudioSource>();
        DontDestroyOnLoad(audio);
        DontDestroyOnLoad(audioButton);
    }

    void Update()
    {
        
    }

    public void MuteAudio()
    {
        if (isMusicActive)
        {
            audio.mute = true;
            isMusicActive = false;
            audioButton.image.sprite = disableVolume;
        }
        else
        {
            audio.mute = false;
            isMusicActive = true;
            audioButton.image.sprite = enableVolume;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text score;

    bool isGameOver = false;
    AudioSource audio;

    void Start()
    // Start is called before the first frame update
    {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
        audio = FindObjectOfType<AudioSource>();
        if (audio != null)
        {
            audio.volume = 1f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount>1)
            {
                gameOverScreen.SetActive(false);
                SceneManager.LoadScene(1);
            }
        }

    }

    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
        score.text = FindObjectOfType<Player>().liveScore.text;
        if(audio != null)
        {
            audio.volume = 0.5f;
        }
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        Destroy(FindObjectOfType<AudioSource>());
        SceneManager.LoadScene(0);
    }
}

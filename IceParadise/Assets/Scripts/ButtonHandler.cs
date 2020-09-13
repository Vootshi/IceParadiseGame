using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonHandler : MonoBehaviour
{
    
    public void NextScene()
    {
        SceneManager.LoadScene(1);

    }

    public void SetText(string text1)
    {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text1;
    }

}

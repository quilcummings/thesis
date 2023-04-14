using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public bool hasPlayed;

    public AudioSource aud;
    public AudioClip tick;

    public void OnButtonPress() {
        aud.PlayOneShot(tick);
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
    }

    public void LoadGame() {
        aud.PlayOneShot(tick);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void OnHover() {
        Debug.Log("Enter");
    
        if(!hasPlayed){
            aud.PlayOneShot(tick);
            hasPlayed = true;
        }
    }

    public void OnExit() {
        Debug.Log("Exit");
        hasPlayed = false;
    }
}

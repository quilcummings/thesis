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
    public AudioClip click;

    public void OnButtonPress() {
        PlayClick();
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
    }

    public void LoadGame() {
        PlayClick();

        LoadMain();
        //Invoke("LoadMain", 3);
        //SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void OnHover() {
        Debug.Log("Enter");
    
        if(!hasPlayed){
            PlayTick();
            hasPlayed = true;
        }
    }

    public void OnExit() {
        Debug.Log("Exit");
        hasPlayed = false;
    }

    public void PlayClick() {
        aud.PlayOneShot(click);
    }

    public void PlayTick() {
        aud.PlayOneShot(tick);
    }

    public void LoadMain(){
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

}

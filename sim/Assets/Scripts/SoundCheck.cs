using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCheck : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource wait;
    //public AudioClip bgm;

    public bool pow = true;

    void Update()
    {
        if (!wait.isPlaying && pow)
        {
            StartCoroutine(delay());
            bgm.Play();
            pow = false;
        }
    }

    IEnumerator delay() {
        yield return new WaitForSeconds(4f);
    }
}
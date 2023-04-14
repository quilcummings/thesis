using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public void OnButtonPress() {
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
        
    }

    public void LoadGame() {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        
    }
}

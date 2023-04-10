using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public void OnButtonPress() {

        Debug.Log("PRESSED");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        
    }
}

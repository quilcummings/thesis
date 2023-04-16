using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject sideBar;

    public void switchOn() {
        sideBar.SetActive(true);
    }

    public void switchOff() {
        sideBar.SetActive(false);
    }
}

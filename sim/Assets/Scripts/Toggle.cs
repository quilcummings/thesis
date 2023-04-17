using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject sideBar;
    public GameObject tog;

    public void switchOn() {
        sideBar.SetActive(true);
    }

    public void switchOff() {
        sideBar.SetActive(false);
    }

    public void hideTog() {
        tog.SetActive(false);
    }

    public void showTog() {
        tog.SetActive(true);
    }
}

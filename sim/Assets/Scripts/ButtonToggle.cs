using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
{
    public GameObject placeWolves;
    public GameObject findWolfPackOne;
    public GameObject findWolfPackTwo;

    public GameObject placeDeer;
    public GameObject findDeerPackOne;
    public GameObject findDeerPackTwo;

    public GameObject placeCoyote;
    public GameObject findCoyotePackOne;
    public GameObject findCoyotePackTwo;

    public GameObject placeRabbits;
    public GameObject findRabbitPackOne;
    public GameObject findRabbitPackTwo;

    public GameObject placeMountainLion;
    public GameObject findMLPackOne;
    public GameObject findMLPackTwo;

    private RectTransform controlRectTransfo;

    private Color newColor = new Color(185f, 165f, 165f, 0.3f);

    void Update()
    {
        toggle(UIManager.wolfFlockNum, placeWolves, findWolfPackOne, findWolfPackTwo, 1);
        toggle(UIManager.deerFlockNum, placeDeer, findDeerPackOne, findDeerPackTwo, 2);
        toggle(UIManager.coyoteFlockNum, placeCoyote, findCoyotePackOne, findCoyotePackTwo, 3);
        toggle(UIManager.rabbitFlockNum, placeRabbits, findRabbitPackOne, findRabbitPackTwo, 4);
        toggle(UIManager.mountainLionFlockNum, placeMountainLion, findMLPackOne, findMLPackTwo, 5);
    }

    public void toggle(int flockNum, GameObject placeGroup, GameObject findPackOne, GameObject findPackTwo, int index)
    {

        if (flockNum == 0)
        {
            controlRectTransfo = placeGroup.GetComponent<RectTransform>();

            placeGroup.GetComponent<Button>().interactable = true;            
            findPackOne.GetComponent<Button>().interactable = false;
            findPackTwo.GetComponent<Button>().interactable = false;
            
        }
        else if (flockNum == 1)
        {
            placeGroup.GetComponent<Button>().interactable = true;            
            findPackOne.GetComponent<Button>().interactable = true;
            findPackTwo.GetComponent<Button>().interactable = false;

        }
        else if (flockNum == 2)
        {
            placeGroup.GetComponent<Button>().interactable = false;            
            findPackOne.GetComponent<Button>().interactable = true;
            findPackTwo.GetComponent<Button>().interactable = true;
        }
    }
}

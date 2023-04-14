using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextEvents : MonoBehaviour
{
    public TMP_Text control;
    private float scale;
    private float mult;
    private RectTransform controlRectTransfo;

    void Start()
    {
        controlRectTransfo = control.GetComponent<RectTransform>();
    }

    void Update() {
        scale = 0.5f;
        if (control.fontSize <= 26.5 && control.fontSize >= 10.5)
        {
            control.fontSize += Input.mouseScrollDelta.y * scale;
        }
        else if(control.fontSize > 26.5 && control.fontSize + Input.mouseScrollDelta.y*scale < control.fontSize)
        {
            control.fontSize += Input.mouseScrollDelta.y * scale;
        }
        else if(control.fontSize < 10.5 && control.fontSize + Input.mouseScrollDelta.y*scale > control.fontSize)
        {
            control.fontSize += Input.mouseScrollDelta.y * scale;
        }

        
        mult = 190;
        if (Input.GetKey(KeyCode.W))
        {
            if (controlRectTransfo.position.y < Screen.height - 50) //550)
            {   
                controlRectTransfo.Translate(Vector3.up * Time.deltaTime * mult, Space.World);
            }
            Debug.Log(controlRectTransfo.position.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (controlRectTransfo.position.x > 100) //110)
            {
                controlRectTransfo.Translate(Vector3.right * Time.deltaTime * mult * -1, Space.World);   
            }
            Debug.Log(controlRectTransfo.position.x);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (controlRectTransfo.position.y > 300)//305)
            {
                controlRectTransfo.Translate(Vector3.up * Time.deltaTime * mult * -1, Space.World);
            }
            Debug.Log(controlRectTransfo.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (controlRectTransfo.position.x < Screen.width - 100) // 1100 )
            {
                controlRectTransfo.Translate(Vector3.right * Time.deltaTime * mult, Space.World);   
            }
            Debug.Log(controlRectTransfo.position.x);
        }
    }
    
}

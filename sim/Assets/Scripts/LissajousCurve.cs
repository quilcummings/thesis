using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LissajousCurve : MonoBehaviour
{
    private float time;
 
    void Update()
    {
        time += Time.deltaTime;
 
        float x = Mathf.Cos(time * 1) * 2;
        float y = Mathf.Sin(time * 2);
 
        transform.position = new Vector3(x, y, 0);
    }
}

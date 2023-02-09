using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 2f;
    public Camera cam;

    float zoom = 5;
 
    void Update() 
    {
        // && cam.orthographicSize >= 3
        if (cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }

        if (Input.GetKey(KeyCode.W)) 
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S)) 
        {
            transform.position -= Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.position -= Vector3.left * Time.deltaTime * speed;
        }
    }

}
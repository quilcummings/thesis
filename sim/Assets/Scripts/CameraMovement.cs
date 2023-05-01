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
            if (cam.orthographicSize <= 0.5 && cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoom > cam.orthographicSize)
            {
                cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
            }
            if (cam.orthographicSize >= 25 && cam.orthographicSize - Input.GetAxis("Mouse ScrollWheel") * zoom < cam.orthographicSize)
            {
                cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
            }
            else if (cam.orthographicSize > 0.5 && cam.orthographicSize < 25)
            {
                cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
            }
            
        }

        
        if (Input.GetKey(KeyCode.W) && transform.position.y <= 15) 
        {
            transform.position += Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -40) 
        {
            transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y >= -15) 
        {
            transform.position -= Vector3.up * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 40) 
        {
            transform.position -= Vector3.left * Time.deltaTime * speed;
        }
    }

}
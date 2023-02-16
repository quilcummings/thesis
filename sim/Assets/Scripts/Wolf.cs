using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : MonoBehaviour
{
    public GameObject manager;
    public Vector2 location = Vector2.zero;
    public Vector2 velocity;
    Vector2 goalPos = Vector2.zero;
    Vector2 currentForce;
    public SpriteRenderer sr;

    void Start()
    {
        velocity = new Vector2(Random.Range(0.01f,0.3f), Random.Range(0.01f, 0.3f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
    }

    Vector2 seek(Vector2 target)
    {
        return(target - location);
    }
    
    void applyForce(Vector2 f)
    {
        Vector3 force = new Vector3(f.x, f.y, 0);
        this.GetComponent<Rigidbody2D>().AddForce(force);
        Debug.DrawRay(this.transform.position, force, Color.white);
    }

    void flock()
    {
        location = this.transform.position;
        velocity = this.GetComponent<Rigidbody2D>().velocity;

        Debug.Log(velocity);

        Vector2 gl;
        gl = seek(goalPos);
        currentForce = gl;
        currentForce = currentForce.normalized;

        applyForce(currentForce);

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(velocity.x, -0.4f, 0.4f), Mathf.Clamp(velocity.y, -0.4f, 0.4f));
    }

    void Update()
    {
        if (velocity.x < 0 && sr != null)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        flock();
        goalPos = manager.transform.position;
    }
}

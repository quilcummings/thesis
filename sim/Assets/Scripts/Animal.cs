using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    //public GameObject manager;
    public Vector2 location = Vector2.zero;
    public Vector2 velocity;
    public Vector2 goalPos = Vector2.zero;
    public Vector2 currentForce;
    public SpriteRenderer sr;

    public float time;

    public bool hungry = false;

    public GameObject[] prey;
    public GameObject[] predator;


    Vector2 seek(Vector2 target)
    {
        return(target - location);
    }

    public void applyForce(Vector2 f)
    {
        Vector3 force = new Vector3(f.x, f.y, 0);
        this.GetComponent<Rigidbody2D>().AddForce(force);
    }

    public void flock(float clamp)
    {
        location = this.transform.position;
        velocity = this.GetComponent<Rigidbody2D>().velocity;

        Vector2 gl;
        
        gl = seek(goalPos);
        currentForce = gl;
        currentForce = currentForce.normalized;

        applyForce(currentForce);

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(velocity.x, -1*clamp, clamp), Mathf.Clamp(velocity.y, -1*clamp, clamp));
    }

    public IEnumerator checkHunger(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            hungry = true;
        }
    }
}

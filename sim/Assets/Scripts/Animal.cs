using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public Vector2 location = Vector2.zero;
    public Vector2 velocity;
    public Vector2 goalPos = Vector2.zero;
    public Vector2 currentForce;
    public SpriteRenderer sr;
    public Rigidbody2D rb;

    public float time;
    public bool hungry = false;
    public bool death = false;
    public bool dead = false;
    public bool check = true;
    

    public GameObject[] prey;
    public GameObject[] predator;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    Vector2 seek(Vector2 target)
    {
        return(target - location);
    }

    public void applyForce(Vector2 f)
    {
        Vector3 force = new Vector3(f.x, f.y, 0);
        rb.AddForce(force);
    }

    public void flock(float clamp)
    {
        location = this.transform.position;
        velocity = rb.velocity;

        Vector2 gl;
        
        gl = seek(goalPos);
        currentForce = gl;
        currentForce = currentForce.normalized;

        applyForce(currentForce);
        
        rb.velocity = new Vector2(Mathf.Clamp(velocity.x, -1*clamp, clamp), Mathf.Clamp(velocity.y, -1*clamp, clamp));
    }

    public void attack(float clamp)
    {
        foreach(GameObject go in prey)
        {
            if (go.activeSelf)
            {
                if(Vector3.Distance(transform.position, go.transform.position) < 3f && hungry)
                {
                    //if (go.transform.position.x > transform.position.x)
                    //{
                    //    sr.flipX = false;
                    //}
                    //else
                    //{
                    //    sr.flipX = true;
                    //}

                    //float step = .1f * Time.deltaTime;
                    //transform.position = Vector3.MoveTowards(transform.position, go.transform.position, step);
                    
                    
                    location = this.transform.position;
                    velocity = rb.velocity;

                    Vector2 gl;
        
                    gl = seek(go.transform.position);
                    currentForce = gl;
                    currentForce = currentForce.normalized;

                    applyForce(currentForce);

                    rb.velocity = new Vector2(Mathf.Clamp(velocity.x, -1*clamp, clamp), Mathf.Clamp(velocity.y, -1*clamp, clamp));

                    hungry = false;
                }
            }
        }
    }

    public IEnumerator checkHunger(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        hungry = true;
    }

    public IEnumerator checkStarvation(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (!hungry)
        {
            yield break;
        }
        if (hungry && !check) 
        {
            death = true;
        }
        
    }
    
    public IEnumerator die()
    {
        yield return new WaitForSeconds(5);
        dead = true;
    }
}
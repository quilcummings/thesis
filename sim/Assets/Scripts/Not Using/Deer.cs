using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    public GameObject manager;
    public Vector2 location = Vector2.zero;
    public Vector2 velocity;
    Vector2 goalPos = Vector2.zero;
    Vector2 currentForce;
    public SpriteRenderer sr;

    private float time;
    GameObject[] wolves;

    void Start()
    {
        wolves = GameObject.FindGameObjectsWithTag("Wolf");

        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
    }

    Vector2 seek(Vector2 target)
    {
        return(target - location);
    }
    
    void applyForce(Vector2 f)
    {
        Vector3 force = new Vector3(f.x, f.y, 0);
        this.GetComponent<Rigidbody2D>().AddForce(force);
    }

    void flock()
    {
        location = this.transform.position;
        velocity = this.GetComponent<Rigidbody2D>().velocity;

        Vector2 gl;
        
        gl = seek(goalPos);
        currentForce = gl;
        currentForce = currentForce.normalized;

        applyForce(currentForce);

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(velocity.x, -0.2f, 0.2f), Mathf.Clamp(velocity.y, -0.2f, 0.2f));
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
        goalPos.x = manager.transform.position.x + Random.Range(-100f,100f);
        goalPos.y = manager.transform.position.y + Random.Range(-100f,100f);

        foreach(GameObject go in wolves)
        {
            if(Vector3.Distance(transform.position, go.transform.position) < 3f)
            {
                float step = .1f * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, go.transform.position, step*-1);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wolf")
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }
}

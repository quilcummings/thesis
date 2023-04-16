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

    public int flockID;

    public bool wolfAt = false;

    public float average;

    //public GameObject flock1;
    //public GameObject flock2;
    
    //public GameObject[] prey;
    //public GameObject[] predator;

    public float flockSpeed;
    public float fleeSpeed;

    public List<GameObject> predator = new List<GameObject>();
    public List<GameObject> prey = new List<GameObject>();

    public GameObject[] remaining;

    Queue<int> flipCount = new Queue<int>();
    public int smooth = 200;


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
                    if (clamp == .5f)
                    {
                        StartCoroutine(wolfAttack());
                    }
                
                    location = this.transform.position;
                    velocity = rb.velocity;

                    Vector2 gl;
        
                    gl = seek(go.transform.position);
                    currentForce = gl;
                    currentForce = currentForce.normalized;

                    applyForce(currentForce);

                    rb.velocity = new Vector2(Mathf.Clamp(velocity.x, -1*clamp, clamp), Mathf.Clamp(velocity.y, -1*clamp, clamp));

                }
            }
        }
    }

    public void flee(float clamp)
    {
        foreach(GameObject go in predator)
        {
            if (go.activeSelf)
            {
                if(Vector3.Distance(transform.position, go.transform.position) < 2f)
                {
                    location = this.transform.position;
                    velocity = rb.velocity;

                    Vector2 gl;
        
                    gl = seek(go.transform.position);
                    currentForce = gl * -1;
                    currentForce = currentForce.normalized;

                    applyForce(currentForce);

                    rb.velocity = new Vector2(Mathf.Clamp(velocity.x, -1*clamp, clamp), Mathf.Clamp(velocity.y, -1*clamp, clamp));

                }
            }
        }
    }

    public void queueFlipCount() {

        if (velocity.x < 0)
        {
            flipCount.Enqueue(-1);
        }
        else
        {
            flipCount.Enqueue(1);
        }
        
        if (flipCount.Count > smooth)
        {
            flipCount.Dequeue();
        }

    }

    public void checkRot() {
 
        int total = 0;

        foreach(var dir in flipCount)
        {
            total+=dir;
        }

        average = total/(float)smooth;
    }

    public void fillPredator(int num, string tag) {
        if (num!=0)
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag(tag)) 
            {
                if (!predator.Contains(obj))
                {
                    predator.Add(obj);
                }
            }
        }
    }
    public void fillPrey(int num, string tag) {
        if (num!=0)
        {
            foreach(GameObject obj in GameObject.FindGameObjectsWithTag(tag)) 
            {
                if (!prey.Contains(obj))
                {
                    prey.Add(obj);
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

    public IEnumerator wolfAttack()
    {
        yield return new WaitForSeconds(1f);
        wolfAt = true;
    }

    public IEnumerator destroy(string tag, GameObject toDestroy)
    {
        Debug.Log("Starting destruction countdown");
        yield return new WaitForSeconds(15f);
        remaining = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject go in remaining)
        {
            if (go.activeSelf)
            {
                Destroy(toDestroy);
                yield break;
            }
        }
    }

}

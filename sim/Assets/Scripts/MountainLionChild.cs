using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MountainLionChild : Animal
{
    Coroutine hunger;
    Coroutine starvation;
    Coroutine dying;

    private GameObject[] combo;

    public GameObject one;
    public GameObject two;
    
    void Start()
    {
        GameObject[] deer = GameObject.FindGameObjectsWithTag("Deer");
        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
        GameObject[] coyotes = GameObject.FindGameObjectsWithTag("Coyote");
        combo = deer.Concat(rabbits).ToArray();
        prey = combo.Concat(coyotes).ToArray();

        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        hunger = StartCoroutine(checkHunger(10f));
    }
    
    void Update()
    {
        if (death)
        {
            gameObject.SetActive(false);
        }
        
        if (hungry && check)
        {
            starvation = StartCoroutine(checkStarvation(60f));
            check = false;
        }
        
        if (velocity.x < 0 && sr != null)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        
        if (hungry)
        {           
            attack(0.6f);   
        }
        
        flock(0.6f);

        if (flockID == 0)
        {
            goalPos.x = MountainLionFlock.Instance.MountainLionFlock1.transform.position.x + Random.Range(-50f,50f);
            goalPos.y = MountainLionFlock.Instance.MountainLionFlock1.transform.position.y + Random.Range(-50f,50f);
        }
        else if (flockID == 1)
        {
            goalPos.x = MountainLionFlock.Instance.MountainLionFlock2.transform.position.x + Random.Range(-50f,50f);
            goalPos.y = MountainLionFlock.Instance.MountainLionFlock2.transform.position.y + Random.Range(-50f,50f);
        }

    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D coll = col.gameObject.GetComponent<Collider2D>();
        if (!hungry && coll.gameObject.tag == "Mountain Lion")
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>());
        }
        else 
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>(), false);
        }

        if (col.gameObject.tag == "Deer" || col.gameObject.tag == "Rabbit" || col.gameObject.tag == "Coyote")
        {
            // if (!hungry)
            // {  
            //     Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>());
            // }
            if (hungry)
            {
                Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>(), false);

                col.gameObject.SetActive(false);

                hungry = false;
                check = true;

                StopCoroutine(hunger);
                StopCoroutine(starvation);
            
                hunger = StartCoroutine(checkHunger(15f));
            } 
        }
    }
}

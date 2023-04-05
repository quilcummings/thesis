using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WolfChild : Animal
{
    Coroutine hunger;
    Coroutine starvation;
    Coroutine dying;
    
    public Animator animator;

    void Start()
    {
        GameObject[] deer = GameObject.FindGameObjectsWithTag("Deer");;
        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");;
        prey = deer.Concat(rabbits).ToArray();

        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        hunger = StartCoroutine(checkHunger(10f));
    }

    
    void Update()
    {
        if (death)
        {
            animator.SetBool("dead", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("Starved to Death");
            gameObject.tag = "Carrion";
            death = false;
            dead = true;
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
        
        // flock(0.6f);
        // goalPos.x = WolfFlockManager.Instance.transform.position.x + Random.Range(-50f,50f);
        // goalPos.y = WolfFlockManager.Instance.transform.position.y + Random.Range(-50f,50f);
    
        if (hungry && !dead)
        {
            attack(.6f);
        }

        flock(0.6f);
        goalPos.x = WolfFlockManager.Instance.transform.position.x + Random.Range(-50f,50f);
        goalPos.y = WolfFlockManager.Instance.transform.position.y + Random.Range(-50f,50f);
       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Deer" || col.gameObject.tag == "Rabbit")
        {
            if (hungry)
            {
                Debug.Log("WOLF EATING");
                col.gameObject.SetActive(false);

                hungry = false;
                check = true;
            
                StopCoroutine(hunger);
                StopCoroutine(starvation);
            
                hunger = StartCoroutine(checkHunger(10f));
            }
        }

        if (col.gameObject.tag == "Coyote" && dead)
        {
            //gameObject.SetActive(false);
        }
    }
}

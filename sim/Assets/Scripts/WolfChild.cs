using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfChild : Animal
{
    IEnumerator hunger;
    IEnumerator starvation;

    void Start()
    {
        prey = GameObject.FindGameObjectsWithTag("Deer");
        
        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        hunger = checkHunger(15f);
        starvation = checkStarvation(60f);

        StartCoroutine(hunger);
        //StartCoroutine(checkHunger(15f));  
    }

    
    void Update()
    {
        if (death)
        {
            gameObject.SetActive(false);
            Debug.Log("Starved to Death");
        }
        if (hungry && check)
        {
            StartCoroutine(starvation);
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
    
        if (hungry)
        {
            foreach(GameObject go in prey)
            {
                if (go.activeSelf)
                {
                    if(Vector3.Distance(transform.position, go.transform.position) < 3f)
                    {
                        if (go.transform.position.x > transform.position.x)
                        {
                            sr.flipX = false;
                        }
                        else
                        {
                            sr.flipX = true;
                        }

                        float step = .1f * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, go.transform.position, step);
                    }
                }
            }
        }

        flock(0.6f);
        goalPos.x = WolfFlockManager.Instance.transform.position.x + Random.Range(-50f,50f);
        goalPos.y = WolfFlockManager.Instance.transform.position.y + Random.Range(-50f,50f);

       
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Deer")
        {
            hungry = false;
            check = true;
            StopCoroutine(starvation);
        }
    }
}

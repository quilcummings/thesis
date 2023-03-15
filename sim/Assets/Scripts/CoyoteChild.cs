using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CoyoteChild : Animal
{
    Coroutine hunger;
    Coroutine starvation;
    Coroutine dying;
    
    void Start()
    {
        GameObject[] deer = GameObject.FindGameObjectsWithTag("Deer");
        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
        GameObject[] deadWolves = GameObject.FindGameObjectsWithTag("Carrion");
        GameObject[] combo = deer.Concat(rabbits).ToArray();
        prey = combo.Concat(deadWolves).ToArray();

        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        hunger = StartCoroutine(checkHunger(15f));
    }
    
    void Update()
    {
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
        
        void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Deer" || col.gameObject.tag == "Rabbit" || col.gameObject.tag == "Carrion")
            {
                hungry = false;
                check = true;

                StopCoroutine(hunger);
                StopCoroutine(starvation);
            
                hunger = StartCoroutine(checkHunger(15f));
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class CoyoteChild : Animal
{
    Coroutine hunger;
    Coroutine starvation;
    Coroutine dying;

    private GameObject[] combo;
    
    void Start()
    {
        GameObject[] deer = GameObject.FindGameObjectsWithTag("Deer");
        GameObject[] rabbits = GameObject.FindGameObjectsWithTag("Rabbit");
        GameObject[] deadWolves = GameObject.FindGameObjectsWithTag("Carrion");
        combo = deer.Concat(rabbits).ToArray();
        prey = combo.Concat(deadWolves).ToArray();

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
            GameObject[] deadWolves = GameObject.FindGameObjectsWithTag("Carrion");
            prey = combo.Concat(deadWolves).ToArray();
            
            attack(0.6f);
            
        }
        
        flock(0.6f);
        goalPos.x = CoyoteFlockManager.Instance.transform.position.x + Random.Range(-50f,50f);
        goalPos.y = CoyoteFlockManager.Instance.transform.position.y + Random.Range(-50f,50f);
        
       
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Deer" || col.gameObject.tag == "Rabbit" || col.gameObject.tag == "Carrion")
        {

            if (hungry)
            {
                Debug.Log("COYOTE EATING");
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


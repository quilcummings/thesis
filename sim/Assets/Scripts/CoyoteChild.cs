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
        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        hunger = StartCoroutine(checkHunger(10f));

        flockSpeed = 0.6f;

        lifeSpan(135f, this.gameObject);
    }
    
    void Update()
    {
        if (death)
        {
            DisplayInfo.Instance.deadAnimals.Add(gameObject);
            gameObject.SetActive(false);
        }
        
        if (hungry && check)
        {
            starvation = StartCoroutine(checkStarvation(60f));
            check = false;
        }

        queueFlipCount();

        if (Time.frameCount % smooth == 0)
        {
            checkRot();

            if (average < 0)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }

        }
        
        if (hungry)
        {

            fillPrey(UIManager.deerFlockNum, "Deer");
            fillPrey(UIManager.rabbitFlockNum, "Rabbit");
            if (GameObject.FindGameObjectsWithTag("Carrion") != null)
            {
                fillPrey(1, "Carrion");
            }

            attack(0.4f);
        }
        
        flock(flockSpeed);

        if (flockID == 0)
        {
            goalPos.x = CoyoteFlock.Instance.CoyoteFlock1.transform.position.x + Random.Range(-50f,50f);
            goalPos.y = CoyoteFlock.Instance.CoyoteFlock1.transform.position.y + Random.Range(-50f,50f);
        }
        else if (flockID == 1)
        {
            goalPos.x = CoyoteFlock.Instance.CoyoteFlock2.transform.position.x + Random.Range(-50f,50f);
            goalPos.y = CoyoteFlock.Instance.CoyoteFlock2.transform.position.y + Random.Range(-50f,50f);
        }

    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D coll = col.gameObject.GetComponent<Collider2D>();

        if (coll.gameObject.tag == "Coyote")
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>());
        }
        else
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>(), false);
        }

        if (col.gameObject.tag == "Deer" || col.gameObject.tag == "Rabbit" || col.gameObject.tag == "Carrion")
        {
            if (hungry)
            {
                Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>(), false);

                DisplayInfo.Instance.deadAnimals.Add(col.gameObject);
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


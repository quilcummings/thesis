using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerChild : Animal
{
    
    void Start()
    {
        predator = GameObject.FindGameObjectsWithTag("Wolf");

        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
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

        flock(0.2f);
        goalPos.x = DeerFlockManager.Instance.transform.position.x + Random.Range(-100f,100f);
        goalPos.y = DeerFlockManager.Instance.transform.position.y + Random.Range(-100f,100f);

        // foreach(GameObject go in predator)
        // {
        //     if(Vector3.Distance(transform.position, go.transform.position) < 2f)
        //     {
        //         float step = .1f * Time.deltaTime;
        //         transform.position = Vector2.MoveTowards(transform.position, go.transform.position, step*-1);
        //     }
        // }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitChild : Animal
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

        flock(0.6f);
        goalPos.x = RabbitFlockManager.Instance.transform.position.x + Random.Range(-100f,100f);
        goalPos.y = RabbitFlockManager.Instance.transform.position.y + Random.Range(-100f,100f);
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

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

        if (flockID == 0)
        {
            goalPos.x = RabbitFlock.Instance.RabbitFlock1.transform.position.x + Random.Range(-50f,50f);
            goalPos.y = RabbitFlock.Instance.RabbitFlock1.transform.position.y + Random.Range(-50f,50f);
        }
        else if (flockID == 1)
        {
            goalPos.x = RabbitFlock.Instance.RabbitFlock2.transform.position.x + Random.Range(-50f,50f);
            goalPos.y = RabbitFlock.Instance.RabbitFlock2.transform.position.y + Random.Range(-50f,50f);
        }
    }
    
    void OnCollisionEnter2D(Collision2D col)
    {
        Collider2D coll = col.gameObject.GetComponent<Collider2D>();
        if (col.gameObject.tag == "Deer" || col.gameObject.tag == "Rabbit")
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>());
        }
        else
        {
            Physics2D.IgnoreCollision(coll, GetComponent<Collider2D>(), false);
        }
    }
}

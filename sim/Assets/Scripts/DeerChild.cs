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

        flock(0.6f);

        if (flockID == 0)
        {
            goalPos.x = DeerFlock.Instance.DeerFlock1.transform.position.x + Random.Range(-75f,75f);
            goalPos.y = DeerFlock.Instance.DeerFlock1.transform.position.y + Random.Range(-75f,75f);
        }
        else if (flockID == 1)
        {
            goalPos.x = DeerFlock.Instance.DeerFlock2.transform.position.x + Random.Range(-75f,75f);
            goalPos.y = DeerFlock.Instance.DeerFlock2.transform.position.y + Random.Range(-75f,75f);
        }

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

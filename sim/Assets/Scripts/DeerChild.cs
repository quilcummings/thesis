using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeerChild : Animal
{
    
    private GameObject[] combo;  

    void Start()
    {
        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        flockSpeed = 0.6f;
        fleeSpeed = 0.02f;

        lifeSpan(120f, this.gameObject);
    }

    void Update()
    {
        // if (velocity.x < 0 && sr != null)
        // {
        //     sr.flipX = true;
        // }
        // else
        // {
        //     sr.flipX = false;
        // }

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

        fillPredator(UIManager.wolfFlockNum, "Wolf");
        fillPredator(UIManager.coyoteFlockNum, "Coyote");
        fillPredator(UIManager.mountainLionFlockNum, "MountainLion");


        flock(flockSpeed);
        flee(fleeSpeed);

        if (flockID == 0)
        {
            goalPos.x = DeerFlock.Instance.DeerFlock1.transform.position.x + Random.Range(-175f,175f);
            goalPos.y = DeerFlock.Instance.DeerFlock1.transform.position.y + Random.Range(-175f,175f);
        }
        else if (flockID == 1)
        {
            goalPos.x = DeerFlock.Instance.DeerFlock2.transform.position.x + Random.Range(-175f,175f);
            goalPos.y = DeerFlock.Instance.DeerFlock2.transform.position.y + Random.Range(-175f,175f);
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

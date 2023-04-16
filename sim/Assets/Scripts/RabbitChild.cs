using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RabbitChild : Animal
{
    private GameObject[] combo;

    void Start()
    {
        velocity = new Vector2(Random.Range(0.1f,0.5f), Random.Range(0.1f, 0.5f));
        location = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);

        flockSpeed = 0.6f;

        lifeSpan(130f, this.gameObject);
    }

    
    void Update()
    {
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
        flee(0.1f);

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

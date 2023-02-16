using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = Random.Range(WolfFlockManager.Instance.minSpeed, WolfFlockManager.Instance.maxSpeed);
    }

    void Update()
    {
        ApplyRules();
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void ApplyRules()
    {
        GameObject[] gos;
        gos = WolfFlockManager.Instance.pack;

        Vector2 vCenter = Vector2.zero;
        Vector2 vAvoid = Vector2.zero;
        float gSpeed = 0.01f;
        float nDistance;
        int groupSize = 0;

        foreach(GameObject go in gos)
        {
            if(go != this.gameObject)
            {
                nDistance = Vector2.Distance(go.transform.position, this.transform.position);
                if (nDistance <= WolfFlockManager.Instance.neighborDistance)
                {
                    vCenter += (Vector2)go.transform.position;
                    groupSize++;

                    if (nDistance < 1.0f)
                    {
                        vAvoid += (Vector2)(this.transform.position - go.transform.position);
                    }

                    Flock another = go.GetComponent<Flock>();
                    gSpeed = gSpeed + another.speed;
                }
            }
        }

        if (groupSize > 0)
        {
            vCenter = vCenter/groupSize;
            speed = gSpeed/groupSize;

            Vector2 direction = (vCenter) + vAvoid - (Vector2)transform.position;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
            
            if (direction != Vector2.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, WolfFlockManager.Instance.rotationSpeed * Time.deltaTime);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfFlockManager : MonoBehaviour
{
    public static WolfFlockManager Instance;

    public GameObject[] pack;
    public GameObject wolfPrefab;
    public int packSize = 5;
    
    public Vector3 limits = new Vector3(1, 1, 1);

    private float randX;
    private float randY;

    // [Header ("Wolf Settings")]
    // [Range(0.0f, 5.0f)]
    // public float minSpeed;
    // [Range(0.0f, 5.0f)]
    // public float maxSpeed;
    // [Range(1.0f, 10.0f)]
    // public float neighborDistance;
    // [Range(1.0f, 5.0f)]
    // public float rotationSpeed;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        pack = new GameObject[packSize];
        for (int i = 0; i < packSize; i++)
        {
            //Vector2 pos = this.transform.position + new Vector2(Random.Range(-limits.x, limits.x), Random.Range(-limits.y, limits.y));
            float posX = this.transform.position.x + Random.Range(-limits.x, limits.x);
            float posY = this.transform.position.y + Random.Range(-limits.y, limits.y);
            float posZ = 0f;
            Vector3 pos = new Vector3(posX, posY, posZ);
            //pack[i] = Instantiate(wolfPrefab, pos, Quaternion.identity);
            pack[i] = Instantiate(wolfPrefab, this.transform.position + pos, Quaternion.identity);
            pack[i].GetComponent<Wolf>().manager = this.gameObject;
        }

        StartCoroutine(randomMovement(15f));
    }

    void Update()
    {
        float step = .1f * Time.deltaTime;
        Vector2 pos = new Vector2(randX, randY);
        transform.position = Vector3.MoveTowards(transform.position, pos, step);
    }

    public IEnumerator randomMovement(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            randY = Random.Range(-15f, 15f);
            if (Mathf.Abs(randY) > 0 && Mathf.Abs(randY) <= 2)
            {
                randX = Random.Range(4f, 16f);
            }
            else if (Mathf.Abs(randY) > 2 && Mathf.Abs(randY) <= 6)
            {
                randX = Random.Range(4f, 14f);
            }
            else if (Mathf.Abs(randY) > 6 && Mathf.Abs(randY) <= 10)
            {
                randX = Random.Range(4f, 11.5f);
            }
            else if (Mathf.Abs(randY) > 10 && Mathf.Abs(randY) <= 14)
            {
                randX = Random.Range(4f, 9f);
            }
            else if (Mathf.Abs(randY) > 14 && Mathf.Abs(randY) <= 15)
            {
                randX = Random.Range(4f, 7.5f);
            }

            Debug.Log("X: " + randX);
            Debug.Log("Y: " + randY);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfFlockManager : MonoBehaviour
{
    public static WolfFlockManager Instance;


    public GameObject wolfPrefab;
    public int packSize = 5;
    public GameObject[] pack;
    public Vector2 limits = new Vector2(1, 1);

    [Header ("Wolf Settings")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighborDistance;
    [Range(1.0f, 5.0f)]
    public float rotationSpeed;


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
            Vector2 pos = new Vector2(posX, posY);
            pack[i] = Instantiate(wolfPrefab, pos, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}

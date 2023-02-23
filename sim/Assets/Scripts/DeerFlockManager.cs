using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerFlockManager : MonoBehaviour
{
    public static DeerFlockManager Instance;

    public GameObject[] herd;
    public GameObject deerPrefab;
    public int herdSize = 10;
    
    public Vector3 limits = new Vector3(1, 1, 1);

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        herd = new GameObject[herdSize];
        for (int i = 0; i < herdSize; i++)
        {
            float posX = this.transform.position.x + Random.Range(-limits.x, limits.x);
            float posY = this.transform.position.y + Random.Range(-limits.y, limits.y);
            float posZ = 0f;
            Vector3 pos = new Vector3(posX, posY, posZ);
            herd[i] = Instantiate(deerPrefab, this.transform.position + pos, Quaternion.identity);
            herd[i].GetComponent<Deer>().manager = this.gameObject;
        }
    }

    void Update()
    {
        
    }
}

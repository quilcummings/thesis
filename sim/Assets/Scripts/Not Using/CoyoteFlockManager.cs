using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteFlockManager : MonoBehaviour
{
    public static CoyoteFlockManager Instance;
    
    public GameObject[] pack;
    public GameObject[] litter;
    public GameObject coyotePrefab;
    public int packSize = 5;
    
    public Vector3 limits = new Vector3(1, 1, 1);
    
    void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        pack = new GameObject[packSize];
        for (int i = 0; i < packSize; i++)
        {
            float posX = this.transform.position.x + Random.Range(-limits.x, limits.x);
            float posY = this.transform.position.y + Random.Range(-limits.y, limits.y);
            float posZ = 0f;
            Vector3 pos = new Vector3(posX, posY, posZ);
            pack[i] = Instantiate(coyotePrefab, this.transform.position + pos, Quaternion.identity);
            //pack[i].GetComponent<Wolf>().manager = this.gameObject;
        }

        StartCoroutine(newCoyotes(120f));
    }

    public IEnumerator newCoyotes(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int litterSize = Random.Range(2, 4);
            
            litter = new GameObject[litterSize];
            for (int i = 0; i < litterSize; i++)
            {
                float posX = this.transform.position.x + Random.Range(-limits.x, limits.x);
                float posY = this.transform.position.y + Random.Range(-limits.y, limits.y);
                float posZ = 0f;
                Vector3 pos = new Vector3(posX, posY, posZ);
                litter[i] = Instantiate(coyotePrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}

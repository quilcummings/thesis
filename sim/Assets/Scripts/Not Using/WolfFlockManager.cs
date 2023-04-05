using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfFlockManager : MonoBehaviour
{
    public static WolfFlockManager Instance;

    public GameObject[] pack;
    public GameObject[] litter;
    public GameObject wolfPrefab;
    public int packSize = 1;
    
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
            pack[i] = Instantiate(wolfPrefab, this.transform.position + pos, Quaternion.identity);
            //pack[i].GetComponent<Wolf>().manager = this.gameObject;
        }

        StartCoroutine(newWolves(60f));
    }

    public IEnumerator newWolves(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int litterSize = Random.Range(3, 5);
            
            litter = new GameObject[litterSize];
            for (int i = 0; i < litterSize; i++)
            {
                litter[i] = Instantiate(wolfPrefab, this.transform.position, Quaternion.identity);
            }
        }
    }
}

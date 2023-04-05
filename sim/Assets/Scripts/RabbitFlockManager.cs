using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitFlockManager : MonoBehaviour
{
    public static RabbitFlockManager Instance;

    public GameObject[] colony;
    public GameObject[] kittens;
    public GameObject rabbitPrefab;
    public int colonySize = 10;
    
    public Vector3 limits = new Vector3(1, 1, 1);
    
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        colony = new GameObject[colonySize];
        for (int i = 0; i < colonySize; i++)
        {
            float posX = this.transform.position.x + Random.Range(-limits.x, limits.x);
            float posY = this.transform.position.y + Random.Range(-limits.y, limits.y);
            float posZ = 0f;
            Vector3 pos = new Vector3(posX, posY, posZ);
            colony[i] = Instantiate(rabbitPrefab, this.transform.position + pos, Quaternion.identity);
        }
        StartCoroutine(newRabbits(40f));
    }

    public IEnumerator newRabbits(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            
            foreach (GameObject go in colony)
            {
                if (go.activeSelf)
                {
                    Instantiate(rabbitPrefab, this.transform.position, Quaternion.identity);
                }
            }
        }
    }
}

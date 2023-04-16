using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitFlock : FlockManager
{
    public static RabbitFlock Instance;

    public int flockID;

    public GameObject RabbitFlock1;
    public GameObject RabbitFlock2;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        groupSize = 10;
        if (flockID == 0)
        {
            //setup(RabbitFlock1);
            //spawnAnimals(40f, 6, 8, flockID, RabbitFlock1);
        }
        else if (flockID == 1)
        {
            //setup(RabbitFlock2);
            //spawnAnimals(40f, 6, 8, flockID, RabbitFlock2);
        }
        
    }

    public void groupOne(int index)
    {
        setup(RabbitFlock1, index);
        spawnAnimals(40f, 5, 7, 0, RabbitFlock1, DisplayInfo.Instance.rabbits);
    }

    public void groupTwo(int index)
    {
        setup(RabbitFlock2, index);
        spawnAnimals(40f, 5, 7, 1, RabbitFlock2, DisplayInfo.Instance.rabbits);
    }
}

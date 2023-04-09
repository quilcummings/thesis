using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerFlock : FlockManager
{

    public static DeerFlock Instance;
   
    public int flockID;

    public GameObject DeerFlock1;
    public GameObject DeerFlock2;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        groupSize = 10;
        if (flockID == 0)
        {
            setup(DeerFlock1);
            spawnAnimals(60f, 4, 6, flockID, DeerFlock1);
        }
        else if (flockID == 1)
        {
            setup(DeerFlock2);
            spawnAnimals(60f, 4, 6, flockID, DeerFlock2);
        }
        
    }
}

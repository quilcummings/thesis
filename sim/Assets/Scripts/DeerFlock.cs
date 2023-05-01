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
            //setup(DeerFlock1);
            //spawnAnimals(60f, 4, 6, flockID, DeerFlock1);
        }
        else if (flockID == 1)
        {
            //setup(DeerFlock2);
            //spawnAnimals(60f, 4, 6, flockID, DeerFlock2);
        }
        
    }

    public void groupOne(int index)
    {
        setup(DeerFlock1, index);
        FlockManager.Instance.limits = new Vector3(4, 4, 4);
        spawnAnimals(60f, 4, 6, 0, DeerFlock1, DisplayInfo.Instance.deer);
    }

    public void groupTwo(int index)
    {
        setup(DeerFlock2, index);
        FlockManager.Instance.limits = new Vector3(4, 4, 4);
        spawnAnimals(60f, 4, 6, 1, DeerFlock2, DisplayInfo.Instance.deer);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainLionFlock : FlockManager
{
    public static MountainLionFlock Instance;

    public int flockID;

    public GameObject MountainLionFlock1;
    public GameObject MountainLionFlock2;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        groupSize = 2;
        if (flockID == 0)
        {
            //setup(MountainLionFlock1);
            //spawnAnimals(60f, 1, 2, flockID, MountainLionFlock1);
        }
        else if (flockID == 1)
        {
            //setup(MountainLionFlock2);
            //spawnAnimals(60f, 1, 2, flockID, MountainLionFlock2);
        }
        
    }

    public void groupOne(int index)
    {
        setup(MountainLionFlock1, index);
        spawnAnimals(60f, 1, 2, 0, MountainLionFlock1, DisplayInfo.Instance.mountainLions);
    }

    public void groupTwo(int index)
    {
        setup(MountainLionFlock2, index);
        spawnAnimals(60f, 1, 2, 1, MountainLionFlock2, DisplayInfo.Instance.mountainLions);
    }
}

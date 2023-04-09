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
            setup(MountainLionFlock1);
        }
        else if (flockID == 1)
        {
            setup(MountainLionFlock2);
        }
        spawnAnimals(60f, 1, 2, flockID);
    }
}

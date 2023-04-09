using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfFlock : FlockManager
{
    public static WolfFlock Instance;

    public int flockID;

    public GameObject WolfFlock1;
    public GameObject WolfFlock2;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        groupSize = 5;
        if (flockID == 0)
        {
            setup(WolfFlock1);
            spawnAnimals(60f, 3, 5, flockID, WolfFlock1);
        }
        else if (flockID == 1)
        {
            setup(WolfFlock2);
            spawnAnimals(60f, 3, 5, flockID, WolfFlock2);
        }
        
    }
}

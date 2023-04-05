using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteFlock : FlockManager
{
    public static CoyoteFlock Instance;

    public int flockID;

    public GameObject CoyoteFlock1;
    public GameObject CoyoteFlock2;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        groupSize = 5;
        if (flockID == 0)
        {
            setup(CoyoteFlock1);
        }
        else if (flockID == 1)
        {
            setup(CoyoteFlock2);
        }
        
        spawnAnimals(120f, 2, 4, flockID);
    }
}

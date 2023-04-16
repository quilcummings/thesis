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
            //setup(CoyoteFlock1);
            //spawnAnimals(120f, 2, 4, flockID, CoyoteFlock1);
        }
        else if (flockID == 1)
        {
            //setup(CoyoteFlock2);
            //spawnAnimals(120f, 2, 4, flockID, CoyoteFlock2);
        }
        
        
    }

    public void groupOne(int index)
    {
        setup(CoyoteFlock1, index);
        spawnAnimals(100f, 2, 4, 0, CoyoteFlock1, DisplayInfo.Instance.coyotes);
    }

    public void groupTwo(int index)
    {
        setup(CoyoteFlock2, index);
        spawnAnimals(100f, 2, 4, 1, CoyoteFlock2, DisplayInfo.Instance.coyotes);
    }
}

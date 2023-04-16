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
            // setup(WolfFlock1, 60);
            // spawnAnimals(60f, 3, 5, flockID, WolfFlock1);
        }
        else if (flockID == 1)
        {
            // setup(WolfFlock2, 41);
            // spawnAnimals(60f, 3, 5, flockID, WolfFlock2);
        }
        
    }

    public void packOne(int index)
    {
        setup(WolfFlock1, index);
        spawnAnimals(60f, 3, 5, 0, WolfFlock1, DisplayInfo.Instance.wolves);
    }

    public void packTwo(int index)
    {
        setup(WolfFlock2, index);
        spawnAnimals(60f, 3, 5, 1, WolfFlock2, DisplayInfo.Instance.wolves);
    }
}

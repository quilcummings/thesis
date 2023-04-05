using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerFlock : FlockManager
{
   
    public GameObject man;

    void Start()
    {
        groupSize = 10;
        setup(man);
        spawnAnimals(60f, 4, 6);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteFlock : FlockManager
{
    public GameObject man;
    void Start()
    {
        groupSize = 5;
        setup(man);
        spawnAnimals(120f, 2, 4);
    }
}

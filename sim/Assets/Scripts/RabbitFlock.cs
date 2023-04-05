using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitFlock : FlockManager
{
    public GameObject man;
    void Start()
    {
        groupSize = 10;
        setup(man);
        spawnAnimals(40f, 6, 8);
    }
}

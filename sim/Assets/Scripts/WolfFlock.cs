using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfFlock : FlockManager
{
    
    public GameObject man;
    void Start()
    {
        groupSize = 5;
        setup(man);
        spawnAnimals(60f, 3, 5);
    }
}

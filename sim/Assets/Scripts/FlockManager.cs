using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlockManager : MonoBehaviour
{
    public static FlockManager Instance;
    
    public GameObject[] group;
    public GameObject[] newAnimals;
    public GameObject prefab;
    //public GameObject manager;
    public int groupSize;
    
    public Vector3 limits = new Vector3(2, 2, 2);

    public Tilemap tilemap;
    public List<Vector3> tileWorldLocations;


    void Awake()
    {
        Instance = this;
    }

    public void setup(GameObject man, int index)
    { 
        tileWorldLocations = new List<Vector3>();

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {   
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPlace);
            if (tilemap.HasTile(localPlace))
            {
                place.x+=1.25f;
                place.y+=1.95f;
                tileWorldLocations.Add(place);
            } 
        }

        var randInt = Random.Range(0, 131);

        //man.transform.position = tileWorldLocations[randInt]; 
        //StartCoroutine(randMovement(5f, randInt, man));

        man.transform.position = tileWorldLocations[index]; 
        StartCoroutine(randMovement(5f, index, man));
    }

    public IEnumerator randMovement(float waitTime, int first, GameObject manager)
    {
        
        yield return new WaitForSeconds(waitTime);

        List<int> matches = new List<int>();
        
        for(int i = 0; i < tileWorldLocations.Count; i++)
        {
           
            if (i != first && (Mathf.Abs(tileWorldLocations[first].x - tileWorldLocations[i].x) < 2 && Mathf.Abs(tileWorldLocations[first].y - tileWorldLocations[i].y) < 2))
            {
                matches.Add(i); 
            }
        }

        // find closest prey manager and move to the adjacent tile closest to that location

        int starter = Random.Range(0, matches.Count);

        //Debug.Log(prefab.tag + "- starter num: " + starter.ToString() + " tile ID: " + matches[starter].ToString() + " matches count: " + matches.Count.ToString());

        manager.transform.position = tileWorldLocations[matches[starter]];
        StartCoroutine(randMovement(5f, matches[starter], manager));

    }

    public void spawnAnimals(float waitTime, int minAdd, int maxAdd, int ID, GameObject man, List<GameObject> list)
    {

        group = new GameObject[groupSize];
        for (int i = 0; i < groupSize; i++)
        {
            float posX = man.transform.position.x + Random.Range(-limits.x, limits.x);
            float posY = man.transform.position.y + Random.Range(-limits.y, limits.y);
            float posZ = 0f;
            Vector3 pos = new Vector3(posX, posY, posZ);
            group[i] = Instantiate(prefab, pos, Quaternion.identity);
         
            group[i].GetComponent<Animal>().flockID = ID;
        }

        StartCoroutine(spawn(waitTime, minAdd, maxAdd, man, ID, list));
    }

    public IEnumerator spawn(float waitTime, int minAdd, int maxAdd, GameObject man, int ID, List<GameObject> list)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            if (list.Count != 0)
            {
                int groupSize = Random.Range(minAdd, maxAdd);
            
                newAnimals = new GameObject[groupSize];
                for (int i = 0; i < groupSize; i++)
                {
                    //Debug.Log(prefab.tag + " " + ID.ToString() + " " + man.transform.position);

                    newAnimals[i] = Instantiate(prefab, man.transform.position, Quaternion.identity);
                    newAnimals[i].GetComponent<Animal>().flockID = ID;
                }
            }
            
        }
    } 
}


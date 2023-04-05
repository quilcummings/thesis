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
    public GameObject manager;
    public int groupSize;
    
    public Vector3 limits = new Vector3(1, 1, 1);

    public Tilemap tilemap;
    public List<Vector3> tileWorldLocations;

    void Awake()
    {
        Instance = this;
    }

    public void setup(GameObject man)
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
        man.transform.position = tileWorldLocations[randInt]; 

        StartCoroutine(randMovement(5f, randInt));

    }

    public IEnumerator randMovement(float waitTime, int first)
    {
        
        yield return new WaitForSeconds(waitTime);

        List<int> matches = new List<int>();
        
        for(int i = 0; i < tileWorldLocations.Count; i++)
        {
            if (i+1 == first)
            {
                i++;
            }
            if (Mathf.Abs(tileWorldLocations[first].x - tileWorldLocations[i].x) < 2 && Mathf.Abs(tileWorldLocations[first].y - tileWorldLocations[i].y) < 2)
            {
                matches.Add(i); 
            }
        }

        int starter = Random.Range(0, matches.Count-1);

        manager.transform.position = tileWorldLocations[matches[starter]];
        StartCoroutine(randMovement(5f, matches[starter]));

    }

    public void spawnAnimals(float waitTime, int minAdd, int maxAdd)
    {

        group = new GameObject[groupSize];
        for (int i = 0; i < groupSize; i++)
        {
            float posX = this.transform.position.x + Random.Range(-limits.x, limits.x);
            float posY = this.transform.position.y + Random.Range(-limits.y, limits.y);
            float posZ = 0f;
            Vector3 pos = new Vector3(posX, posY, posZ);
            group[i] = Instantiate(prefab, this.transform.position, Quaternion.identity);
        }

        StartCoroutine(spawn(waitTime, minAdd, maxAdd));
    }

    public IEnumerator spawn(float waitTime, int minAdd, int maxAdd)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            int groupSize = Random.Range(minAdd, maxAdd);
            
            newAnimals = new GameObject[groupSize];
            for (int i = 0; i < groupSize; i++)
            {
                newAnimals[i] = Instantiate(prefab, this.transform.position, Quaternion.identity);
            }
        }
    } 
}


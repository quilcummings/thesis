using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlockManager : MonoBehaviour
{
    public Tilemap tilemap;

    public GameObject WolfManager;
    public GameObject RabbitManager;
    public GameObject CoyoteManager;
    public GameObject DeerManager;

    private List<Vector3> tileWorldLocations;


    void Start() 
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
        WolfManager.transform.position = tileWorldLocations[randInt]; 

        StartCoroutine(randMovement(5f, randInt));
        
    }

    void Update()
    {

    }

    public IEnumerator randMovement(float waitTime, int first)
    {
        
        yield return new WaitForSeconds(waitTime);

        List<int> matches = new List<int>();
        
        for(int i = 0; i < tileWorldLocations.Count; i++)
        {
            if (i+1 == first)
            {
                Debug.Log("DUPS");
                i++;
            }
            if (Mathf.Abs(tileWorldLocations[first].x - tileWorldLocations[i].x) < 2 && Mathf.Abs(tileWorldLocations[first].y - tileWorldLocations[i].y) < 2)
            {
                matches.Add(i);
                Debug.Log("FOUND MATCH");  
            }
        }

        int starter = Random.Range(0, matches.Count-1);

        Debug.Log("MOVEE");
        WolfManager.transform.position = tileWorldLocations[matches[starter]];
        StartCoroutine(randMovement(5f, matches[starter]));

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OnMouseOver : MonoBehaviour
{
    public Tilemap tilemap;
    public List<Vector3> tileWorldLocations;

    public float min;
    public float index;
    
    void Start() {

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
       
	}

    void Update () {

        if (Input.GetMouseButtonDown(0))
        { 
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("POS" + worldPosition);
            
            for(int i = 0; i < tileWorldLocations.Count; i++)
            {
                float dist = Vector3.Distance(worldPosition, tileWorldLocations[i]);
                if (i == 0)
                {
                    min = dist;
                    index = i;
                }
                else if (dist < min)
                {
                    min = dist;
                    index = i;
                }
            }
            
        }
        
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    public static DisplayInfo Instance;

    public List<GameObject> wolves = new List<GameObject>();
    public List<GameObject> rabbits = new List<GameObject>();
    public List<GameObject> deer = new List<GameObject>();
    public List<GameObject> coyotes = new List<GameObject>();
    public List<GameObject> mountainLions = new List<GameObject>();

    public List<GameObject> deadWolves = new List<GameObject>();
    public List<GameObject> deadRabbits = new List<GameObject>();
    public List<GameObject> deadDeer = new List<GameObject>();
    public List<GameObject> deadCoyotes = new List<GameObject>();
    public List<GameObject> deadMountainLions = new List<GameObject>();

    public List<GameObject> deadAnimals = new List<GameObject>();

    // public int wolfDeathCount;
    // public int rabbitDeathCount;
    // public int deerDeathCount;
    // public int coyoteDeathCount;
    // public int mountainLionDeathCount;

    // public int wolfCount;
    // public int rabbitCount;
    // public int deerCount;
    // public int coyoteCount;
    // public int mountainLionCount;

    public TMP_Text wolfDeaths;
    public TMP_Text wolvesAlive;
    public TMP_Text deerDeaths;
    public TMP_Text deerAlive;
    public TMP_Text rabbitDeaths;
    public TMP_Text rabbitsAlive;
    public TMP_Text coyoteDeaths;
    public TMP_Text coyotesAlive;
    public TMP_Text mountainLionDeaths;
    public TMP_Text mountainLionsAlive;
    
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        UpdateLists();
    }

    public void UpdateLists()
    {
        foreach(GameObject obj in deadAnimals)
        {
            if (obj.tag == "Rabbit" && !deadRabbits.Contains(obj))
            {
                deadRabbits.Add(obj);
                rabbits.Remove(obj);
            }
            else if (obj.tag == "Deer" && !deadDeer.Contains(obj))
            {
                deadDeer.Add(obj);
                deer.Remove(obj);
            }
            else if (obj.tag == "Coyote" && !deadCoyotes.Contains(obj))
            {
                deadCoyotes.Add(obj);
                coyotes.Remove(obj);
            }
            else if (obj.tag == "MountainLion" && !deadMountainLions.Contains(obj))
            {
                deadMountainLions.Add(obj);
                mountainLions.Remove(obj);
            }

        }
        
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Wolf")) 
        {
            if (obj.activeSelf && !wolves.Contains(obj))
            {
                wolves.Add(obj);
            }
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Carrion")) 
        {
            if (obj.activeSelf && !deadWolves.Contains(obj))
            {
                wolves.Remove(obj);
                deadWolves.Add(obj);
            }
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Rabbit")) 
        {
            if (obj.activeSelf && !rabbits.Contains(obj))
            {
                rabbits.Add(obj);
            }
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Deer")) 
        {
            if (obj.activeSelf && !deer.Contains(obj))
            {
                deer.Add(obj);
            }
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Coyote")) 
        {
            if (obj.activeSelf && !coyotes.Contains(obj))
            {
                coyotes.Add(obj);
            } 
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("MountainLion")) 
        {
            if (obj.activeSelf && !mountainLions.Contains(obj))
            {
                mountainLions.Add(obj);
            }
        }


        wolvesAlive.text = "alive - " + wolves.Count.ToString();
        wolfDeaths.text = "deaths - " + deadWolves.Count.ToString();
        deerAlive.text = "alive - " + deer.Count.ToString();
        deerDeaths.text = "deaths - " + deadDeer.Count.ToString();
        rabbitsAlive.text = "alive - " + rabbits.Count.ToString();
        rabbitDeaths.text = "deaths - " + deadRabbits.Count.ToString();
        coyotesAlive.text = "alive - " + coyotes.Count.ToString();
        coyoteDeaths.text = "deaths - " + deadCoyotes.Count.ToString();
        mountainLionsAlive.text = "alive - " + mountainLions.Count.ToString();
        mountainLionDeaths.text = "deaths - " + deadMountainLions.Count.ToString();

    }
}

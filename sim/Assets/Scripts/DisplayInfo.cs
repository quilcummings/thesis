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

    public List<GameObject> wolvesOne = new List<GameObject>();
    public List<GameObject> wolvesTwo = new List<GameObject>();

    public List<GameObject> rabbitsOne = new List<GameObject>();
    public List<GameObject> rabbitsTwo = new List<GameObject>();

    public List<GameObject> deerOne = new List<GameObject>();
    public List<GameObject> deerTwo = new List<GameObject>();

    public List<GameObject> coyotesOne = new List<GameObject>();
    public List<GameObject> coyotesTwo = new List<GameObject>();

    public List<GameObject> mountainLionsOne = new List<GameObject>();
    public List<GameObject> mountainLionsTwo = new List<GameObject>();


    public List<GameObject> deadAnimals = new List<GameObject>();

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
                if (rabbitsOne.Contains(obj))
                {
                    rabbitsOne.Remove(obj);
                }
                else if (rabbitsTwo.Contains(obj))
                {
                    rabbitsTwo.Remove(obj);
                }
            }
            else if (obj.tag == "Deer" && !deadDeer.Contains(obj))
            {
                deadDeer.Add(obj);
                deer.Remove(obj);
                if (deerOne.Contains(obj))
                {
                    deerOne.Remove(obj);
                }
                else if (deerTwo.Contains(obj))
                {
                    deerTwo.Remove(obj);
                }
            }
            else if (obj.tag == "Coyote" && !deadCoyotes.Contains(obj))
            {
                deadCoyotes.Add(obj);
                coyotes.Remove(obj);
                if (coyotesOne.Contains(obj))
                {
                    coyotesOne.Remove(obj);
                }
                else if (coyotesTwo.Contains(obj))
                {
                    coyotesTwo.Remove(obj);
                }
            }
            else if (obj.tag == "MountainLion" && !deadMountainLions.Contains(obj))
            {
                deadMountainLions.Add(obj);
                mountainLions.Remove(obj);
                if (mountainLionsOne.Contains(obj))
                {
                    mountainLionsOne.Remove(obj);
                }
                else if (mountainLionsTwo.Contains(obj))
                {
                    mountainLionsTwo.Remove(obj);
                }
            }

        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Carrion")) 
        {
            if (obj.activeSelf && !deadWolves.Contains(obj))
            {
                wolves.Remove(obj);
                deadWolves.Add(obj);

                if (obj.GetComponent<Animal>().flockID == 0 && wolvesOne.Contains(obj))
                {
                    wolvesOne.Remove(obj);
                }
                else if (obj.GetComponent<Animal>().flockID == 1 && wolvesTwo.Contains(obj))
                {
                    wolvesTwo.Remove(obj);
                }
            }
        }

        
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Wolf")) 
        {
            if (obj.activeSelf)
            {
                if (!wolves.Contains(obj))
                {
                    wolves.Add(obj);
                }
                if (obj.GetComponent<Animal>().flockID == 0 && !wolvesOne.Contains(obj))
                {
                    wolvesOne.Add(obj);
                }
                else if (obj.GetComponent<Animal>().flockID == 1 && !wolvesTwo.Contains(obj))
                {
                    wolvesTwo.Add(obj);
                }
                
            }
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Rabbit")) 
        {
            if (obj.activeSelf)
            {
                if (!rabbits.Contains(obj))
                {
                    rabbits.Add(obj);
                }
                if (obj.GetComponent<Animal>().flockID == 0 && !rabbitsOne.Contains(obj))
                {
                    rabbitsOne.Add(obj);
                }
                else if (obj.GetComponent<Animal>().flockID == 1 && !rabbitsTwo.Contains(obj))
                {
                    rabbitsTwo.Add(obj);
                }
                
            }
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Deer")) 
        {
            if (obj.activeSelf)
            {
                if (!deer.Contains(obj))
                {
                    deer.Add(obj);
                }
                if (obj.GetComponent<Animal>().flockID == 0 && !deerOne.Contains(obj))
                {
                    deerOne.Add(obj);
                }
                else if (obj.GetComponent<Animal>().flockID == 1 && !deerTwo.Contains(obj))
                {
                    deerTwo.Add(obj);
                }
                
            }
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Coyote")) 
        {
            if (obj.activeSelf)
            {
                if (!coyotes.Contains(obj))
                {
                    coyotes.Add(obj);
                }
                if (obj.GetComponent<Animal>().flockID == 0 && !coyotesOne.Contains(obj))
                {
                    coyotesOne.Add(obj);
                }
                else if (obj.GetComponent<Animal>().flockID == 1 && !coyotesTwo.Contains(obj))
                {
                    coyotesTwo.Add(obj);
                }
            } 
        }

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("MountainLion")) 
        {
            if (obj.activeSelf)
            {
                if (!mountainLions.Contains(obj))
                {
                    mountainLions.Add(obj);
                }
                if (obj.GetComponent<Animal>().flockID == 0 && !mountainLionsOne.Contains(obj))
                {
                    mountainLionsOne.Add(obj);
                }
                else if (obj.GetComponent<Animal>().flockID == 1 && !mountainLionsTwo.Contains(obj))
                {
                    mountainLionsTwo.Add(obj);
                }
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

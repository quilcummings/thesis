using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public static DisplayStats Instance;

    public TMP_Text stats;
    List<GameObject> list = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }
    public void UpdateStats(int index)
    {
        int hungryCount = 0;
        int attackingCount = 0;
        int exploringCount = 0;
        

        if (index == 1)
        {
            list = DisplayInfo.Instance.wolvesOne;
        }
        else if (index == 2)
        {
            list = DisplayInfo.Instance.wolvesTwo;
        }
        else if (index == 3)
        {
            list = DisplayInfo.Instance.deerOne;
        }
        else if (index == 4)
        {
            list = DisplayInfo.Instance.deerTwo;
        }
        else if (index == 5)
        {
            list = DisplayInfo.Instance.coyotesOne;
        }
        else if (index == 6)
        {
            list = DisplayInfo.Instance.coyotesTwo;
        }
        else if (index == 7)
        {
            list = DisplayInfo.Instance.rabbitsOne;
        }
        else if (index == 8)
        {
            list = DisplayInfo.Instance.wolvesTwo;
        }
        else if (index == 9)
        {
            list = DisplayInfo.Instance.wolvesTwo;
        }
        else if (index == 10)
        {
            list = DisplayInfo.Instance.wolvesTwo;
        }

        foreach(GameObject obj in list)
        {
            if (obj.GetComponent<Animal>().hungry)
            {
                hungryCount++;
            }
            if (obj.GetComponent<Animal>().attacking)
            {
                attackingCount++;
            }
            else
            {
                exploringCount++;
            }
        }
        stats.text = "hungry - " + hungryCount.ToString() + "\n" + "attacking - " + attackingCount.ToString() + "\n" + "exploring - " + exploringCount.ToString();
    }
}

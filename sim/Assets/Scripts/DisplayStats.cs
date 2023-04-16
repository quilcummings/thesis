using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    public TMP_Text stats;

    public void UpdateStatsPackOne()
    {
        int hungryCount = 0;
        foreach(GameObject obj in DisplayInfo.Instance.wolvesOne)
        {
            if (obj.GetComponent<Animal>().hungry)
            {
                hungryCount++;
            }
        }
        stats.text = "hungry - " + hungryCount.ToString();
    }
}

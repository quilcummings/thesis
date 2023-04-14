using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDown : MonoBehaviour
{
    
    public void wolfSelect(int index)
    {
        switch (index)
        {
            case 0: 
                UIManager.wolfFlockNum = 0;
                break;
            case 1: 
                UIManager.wolfFlockNum = 1;
                break;
            case 2: 
                UIManager.wolfFlockNum = 2;
                break;
        }
    }

    public void rabbitSelect(int index)
    {
        switch (index)
        {
            case 0: 
                UIManager.rabbitFlockNum = 0;
                break;
            case 1: 
                UIManager.rabbitFlockNum = 1;
                break;
            case 2: 
                UIManager.rabbitFlockNum = 2;
                break;
        }
    }

    public void deerSelect(int index)
    {
        switch (index)
        {
            case 0: 
                UIManager.deerFlockNum = 0;
                break;
            case 1: 
                UIManager.deerFlockNum = 1;
                break;
            case 2: 
                UIManager.deerFlockNum = 2;
                break;
        }
    }

    public void coyoteSelect(int index)
    {
        switch (index)
        {
            case 0: 
                UIManager.coyoteFlockNum = 0;
                break;
            case 1: 
                UIManager.coyoteFlockNum = 1;
                break;
            case 2: 
                UIManager.coyoteFlockNum = 2;
                break;
        }
    }

    public void mountainLionSelect(int index)
    {
        switch (index)
        {
            case 0: 
                UIManager.mountainLionFlockNum = 0;
                break;
            case 1: 
                UIManager.mountainLionFlockNum = 1;
                break;
            case 2: 
                UIManager.mountainLionFlockNum = 2;
                break;
        }
    }
}

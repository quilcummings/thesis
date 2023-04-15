using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class UIFlock : MonoBehaviour
{
    public TMP_Text dialogue;
    float min;
    float index;

    public Tilemap tilemap;
    public List<Vector3> tileWorldLocations;

    public bool second = false;
    public bool pow = true;

    public bool wolvesDone = false;
    public bool deerDone = false;
    public bool coyotesDone = false;
    public bool rabbitsDone = false;
    public bool mountainLionsDone = false;

    public bool done = false;

    public AudioSource aud;
    public AudioClip click;


    void Start ()
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
    }

    void Update() {
        
        if (UIManager.wolfFlockNum == 0)
        {
            wolvesDone = true;
        }
        if (UIManager.deerFlockNum == 0)
        {
            deerDone = true;
        }
        if (UIManager.coyoteFlockNum == 0)
        {
            coyotesDone = true;
        }
        if (UIManager.rabbitFlockNum == 0)
        {
            rabbitsDone = true;
        }
        if (UIManager.mountainLionFlockNum == 0)
        {
            mountainLionsDone = true;
        }


        if (UIManager.wolfFlockNum == 0 && UIManager.rabbitFlockNum == 0 && UIManager.coyoteFlockNum == 0 && UIManager.mountainLionFlockNum == 0 && UIManager.deerFlockNum == 0)
        {
            dialogue.text = "VOID MAP";
        }
        else if (UIManager.wolfFlockNum != 0 && !wolvesDone)
        {
            wolves();
            //aud.PlayOneShot(click);
        }
        else if (UIManager.deerFlockNum != 0 && !deerDone && wolvesDone)
        {
            deer();
            //aud.PlayOneShot(click);
        }
        else if (UIManager.coyoteFlockNum != 0 && !coyotesDone && deerDone)
        {
            coyotes();
            //aud.PlayOneShot(click);
        }
        else if (UIManager.rabbitFlockNum != 0 && !rabbitsDone && coyotesDone)
        {
            rabbits();
            //aud.PlayOneShot(click);
        }
        else if (UIManager.mountainLionFlockNum != 0 && !mountainLionsDone && rabbitsDone)
        {
            mountainLions();
            //aud.PlayOneShot(click);
        }
        else
        {
            done = true;
        }
        
    }

    public void wolves() {
        if (UIManager.wolfFlockNum == 1)
        {
            dialogue.text = "Choose a location for your wolf pack";
            if (Input.GetMouseButtonDown(0))
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                WolfFlock.Instance.packOne(ind);
                wolvesDone = true;
            }
        }
        else if (UIManager.wolfFlockNum == 2)
        {
            if (pow)
            {
                dialogue.text = "Choose a location for your first wolf pack";
                pow = false;
            }
            if (Input.GetMouseButtonDown(0) && !second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                WolfFlock.Instance.packOne(ind);
                
                StartCoroutine(pause());
                dialogue.text = "Choose a location for your second wolf pack";
                
            }
            else if (Input.GetMouseButtonDown(0) && second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                WolfFlock.Instance.packTwo(ind);
                second = false;
                wolvesDone = true;
                pow = true;
                dialogue.text = "";
            }
        }
    }

    public void deer() {
        if (UIManager.deerFlockNum == 1)
        {
            dialogue.text = "Choose a location for your deer herd";
            if (Input.GetMouseButtonDown(0))
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                DeerFlock.Instance.groupOne(ind);
                deerDone = true;
                dialogue.text = "";
            }
        }
        else if (UIManager.deerFlockNum == 2)
        {
            if (pow)
            {
                dialogue.text = "Choose a location for your first deer herd";
                pow = false;
            }
            if (Input.GetMouseButtonDown(0) && !second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                DeerFlock.Instance.groupOne(ind);
                
                StartCoroutine(pause());
                dialogue.text = "Choose a location for your second deer herd";

            }
            else if (Input.GetMouseButtonDown(0) && second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                DeerFlock.Instance.groupTwo(ind);
                second = false;
                deerDone = true;
                pow = true;
                dialogue.text = "";
            }
        }
    }


    public void rabbits() {
        if (UIManager.rabbitFlockNum == 1)
        {
            dialogue.text = "Choose a location for your rabbit colony";
            if (Input.GetMouseButtonDown(0))
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                RabbitFlock.Instance.groupOne(ind);
                rabbitsDone = true;
                dialogue.text = "";
            }
        }
        else if (UIManager.rabbitFlockNum == 2)
        {
            if (pow)
            {
                dialogue.text = "Choose a location for your first rabbit colony";
                pow = false;
            }
            if (Input.GetMouseButtonDown(0) && !second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                RabbitFlock.Instance.groupOne(ind);
                
                StartCoroutine(pause());
                dialogue.text = "Choose a location for your second rabbit colony";

            }
            else if (Input.GetMouseButtonDown(0) && second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                RabbitFlock.Instance.groupTwo(ind);
                second = false;
                rabbitsDone = true;
                pow = true;
                dialogue.text = "";
            }
        }
    }
    public void coyotes() {
        if (UIManager.coyoteFlockNum == 1)
        {
            dialogue.text = "Choose a location for your coyote pack";
            if (Input.GetMouseButtonDown(0))
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                CoyoteFlock.Instance.groupOne(ind);
                coyotesDone = true;
                dialogue.text = "";
            }
        }
        else if (UIManager.coyoteFlockNum == 2)
        {
            if (pow)
            {
                dialogue.text = "Choose a location for your first coyote pack";
                pow = false;
            }
            if (Input.GetMouseButtonDown(0) && !second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                CoyoteFlock.Instance.groupOne(ind);
                
                StartCoroutine(pause());
                dialogue.text = "Choose a location for your second coyote pack";

            }
            else if (Input.GetMouseButtonDown(0) && second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                CoyoteFlock.Instance.groupTwo(ind);
                second = false;
                coyotesDone = true;
                pow = true;
                dialogue.text = "";
            }
        }
    }
    public void mountainLions() {
        if (UIManager.mountainLionFlockNum == 1)
        {
            dialogue.text = "Choose a location for your mountain lion pride";
            if (Input.GetMouseButtonDown(0))
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                MountainLionFlock.Instance.groupOne(ind);
                mountainLionsDone = true;
                dialogue.text = "";
            }
        }
        else if (UIManager.mountainLionFlockNum == 2)
        {
            if (pow)
            {
                dialogue.text = "Choose a location for your first mountain lion pride";
                pow = false;
            }
            if (Input.GetMouseButtonDown(0) && !second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                MountainLionFlock.Instance.groupOne(ind);
                
                StartCoroutine(pause());
                dialogue.text = "Choose a location for your second mountain lion pride";

            }
            else if (Input.GetMouseButtonDown(0) && second)
            {  
                aud.PlayOneShot(click);
                int ind = getIndex();
                MountainLionFlock.Instance.groupTwo(ind);
                second = false;
                mountainLionsDone = true;
                pow = true;
                dialogue.text = "";
            }
        }
    }
    

    public int getIndex()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
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

        return (int)index;
    }

    IEnumerator pause() {
        yield return new WaitForSeconds(1f);
        second = true;
    }
}

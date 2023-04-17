using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{
    public static ButtonPress Instance;

    public bool hasPlayed;

    public AudioSource aud;
    public AudioClip tick;
    public AudioClip click;

    public Camera cam;

    public GameObject wolfOne;
    public GameObject wolfTwo;

    public GameObject Tab;
    public float TabOffset;
    public int selectCount;

    private RectTransform controlRectTransfo;

    void Awake()
    {
        Instance = this;
    }
    public void OnButtonPress() {
        PlayClick();
        SceneManager.LoadScene("UI", LoadSceneMode.Single);
    }

    public void LoadGame() {
        PlayClick();

        LoadMain();
        //Invoke("LoadMain", 3);
        //SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void OnHover() {
    
        if(!hasPlayed){
            PlayTick();
            hasPlayed = true;
        }
    }

    public void OnExit() {
        hasPlayed = false;
    }

    public void PlayClick() {
        aud.PlayOneShot(click);
    }

    public void PlayTick() {
        if (GetComponent<Button>().interactable)
        {
            aud.PlayOneShot(tick);
        }
        //aud.PlayOneShot(tick);
    }

    public void LoadMain(){
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }

    public void Quit() {
        Application.Quit();
    }

    public void placeWolfPack()
    {
        if (UIManager.wolfFlockNum < 2)
        {
            UIFlock.Instance.wolvesDone = false;
            UIManager.wolfFlockNum += 1;
            UIFlock.Instance.buttonPressed = true;
        }
        
    }
    public void placeDeerHerd()
    {
        if (UIManager.deerFlockNum < 2)
        {
            UIFlock.Instance.deerDone = false;
            UIManager.deerFlockNum += 1;
            UIFlock.Instance.dbuttonPressed = true;
        }
    }
    public void placeCoyotePack()
    {
        if (UIManager.coyoteFlockNum < 2)
        {
            UIFlock.Instance.coyotesDone = false;
            UIManager.coyoteFlockNum += 1;
            UIFlock.Instance.cbuttonPressed = true;
        }
        
    }
    public void placeRabbitColony()
    {
        if (UIManager.rabbitFlockNum < 2)
        {
            UIFlock.Instance.rabbitsDone = false;
            UIManager.rabbitFlockNum += 1;
            UIFlock.Instance.rbuttonPressed = true;
        }        
    }
    public void placeMLGroup()
    {
        
        if (UIManager.mountainLionFlockNum < 2)
        {
            UIFlock.Instance.mountainLionsDone = false;
            UIManager.mountainLionFlockNum += 1;
            UIFlock.Instance.mlbuttonPressed = true;
        }
    }

    public void findGroup(GameObject manager)
    {
        aud.PlayOneShot(click);
        var step =  500 * Time.deltaTime; 

        var posX = manager.transform.position.x;
        var posY = manager.transform.position.y;
        Vector3 position = new Vector3(posX, posY, -10);

        cam.transform.position = position;
        //cam.transform.position = Vector3.MoveTowards(cam.transform.position, position, step);
    }

    public void hideTab() 
    {
        Tab.SetActive(false);
    }
    public void showTab()
    {
        if (GetComponent<Button>().interactable)
        {  
            Tab.SetActive(true);
            DisplayStats.Instance.UpdateStats(selectCount);
            controlRectTransfo = Tab.GetComponent<RectTransform>();
            controlRectTransfo.anchoredPosition = new Vector3(-136f, TabOffset, 0f);
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject startplay;
    public GameObject startgame;

    GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Start()
    {
        Begin();
    }

    public void Begin()
    {
        startplay.SetActive(true);
        startgame.SetActive(true);

        Invoke("CloseTheUI", 2);
        Invoke("CloseTheText", 4);
        Invoke("StartPlay", 4.5f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseTheUI()
    {
        startplay.SetActive(false);
    }

    public void CloseTheText()
    {
        startgame.SetActive(false);
    }

    void StartPlay()
    {
        gameController.canShoot = true;
    }
}

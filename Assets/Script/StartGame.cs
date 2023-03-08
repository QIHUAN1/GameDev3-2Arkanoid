using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject startplay;
    public GameObject startgame;
    void Start()
    {
        startplay.SetActive(true);
        startgame.SetActive(true);

        Invoke("CloseTheUI", 2);
        Invoke("CloseTheText", 4);
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
}

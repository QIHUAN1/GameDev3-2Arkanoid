using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool canShoot;


    public TMPro.TextMeshProUGUI playerHPtext;
    public int playerHp;
    
    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
        playerHp = 3;
    }

    // Update is called once per frame
    void Update()
    {
        playerHPtext.text = playerHp.ToString("0");
    }
  
}

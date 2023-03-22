using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool canShoot;

    public TMPro.TextMeshProUGUI Score;
    public float playerScore;


    public TMPro.TextMeshProUGUI brickLeft;
    public int Brick;

    public TMPro.TextMeshProUGUI playerHPtext;
    public int playerHp;

    [SerializeField]
    private GameObject EnemyPrefeb;

    public GameObject Target;

    AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        canShoot = false;
        playerHp = 3;

        playerScore = 0;

        Brick = 64;

        Invoke("PlaySound", 4.5f);
    }

    // Update is called once per frame
    void Update()
    {
        playerHPtext.text = playerHp.ToString("0");

        Score.text = playerScore.ToString("0");

        brickLeft.text = Brick.ToString("0");


        if(Brick == 0)
        {
            SceneManager.LoadScene(1);
        } 
    }

    void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }


}

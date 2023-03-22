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



    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
        playerHp = 3;

        playerScore = 0;

        Brick = 64;
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

    public void SpawnIt(GameObject enemy)
    {
        GameObject newEnemy = Instantiate(enemy, new Vector3(Target.transform.position.x, Target.transform.position.y, 0), Quaternion.identity);
    }

}

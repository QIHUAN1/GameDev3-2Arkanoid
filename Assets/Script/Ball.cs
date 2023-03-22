using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public float minY;

    Vector3 lastVelocity;

    Rigidbody2D rb;

    [SerializeField]
    private float Thespeed;

    GameController gameController;
    StartGame startGame;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        startGame = GameObject.Find("Canvas").GetComponent<StartGame>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        lastVelocity = rb.velocity;

        if(Input.GetButtonDown("Fire1") && gameController.canShoot == true)
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            rb.AddForce(new Vector2(0, 170));
            gameController.canShoot = false;
        }


        if(transform.position.y < minY)
        {

                ResetBall();

        }

        if(Thespeed > 6)
        {
            Thespeed = 6;
        }


    }


    void ResetBall ()
    {
       if(gameController.playerHp > 0 )
        {
            gameObject.transform.position = new Vector3(-1.377f, -3.537f, 0);
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;

            gameController.playerHp -= 1;
            startGame.Begin();
        }
        
        if(gameController.playerHp <= 0 )
        {
            SceneManager.LoadScene(0);
        }
    }

    public GameObject redPowerUp;
    public GameObject bluePowerUp;
    public GameObject pinkPowerUp;
    public GameObject greenPowerUp;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Thespeed = lastVelocity.magnitude + 0.1f * Time.deltaTime;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(Thespeed, 0.1f);
        
        if(collision.gameObject.CompareTag("BlockRed"))
        {
            Destroy(collision.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

           int Spawn1 =  Random.Range(0, 3);

            if(Spawn1 == 1)
            {
                Instantiate(redPowerUp,collision.transform);
            }
        }

        if (collision.gameObject.CompareTag("BlockBlue"))
        {
            Destroy(collision.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

            int Spawn1 = Random.Range(0, 3);

            if (Spawn1 == 1)
            {
                Instantiate(bluePowerUp,collision.transform);
            }
        }

        if (collision.gameObject.CompareTag("BlockPink"))
        {
            Destroy(collision.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

            int Spawn1 = Random.Range(0, 3);

            if (Spawn1 == 1)
            {
                Instantiate(pinkPowerUp, collision.transform);
            }
        }

        if (collision.gameObject.CompareTag("BlockGreen"))
        {
            Destroy(collision.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

            int Spawn1 = Random.Range(0, 3);

            if (Spawn1 == 1)
            {
                Instantiate(greenPowerUp, collision.transform);
            }
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
           
        }
    }
}

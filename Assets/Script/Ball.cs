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
    ThePlatform thePlatform;

    public bool absorbingMode;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        startGame = GameObject.Find("Canvas").GetComponent<StartGame>();
        thePlatform = GameObject.Find("Platform").GetComponent<ThePlatform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        absorbingMode = false;
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

        if (transform.position.y < minY)
        {

                ResetBall();

        }

        if(Thespeed > 6)
        {
            Thespeed = 6;
        }

        if(absorbingMode == true)
        {
            gameObject.transform.position = new Vector3(GameObject.Find("Platform").transform.position.x, -3.6f, 0);
        }

        if (absorbingMode == true && Input.GetButtonDown("Fire1"))
        {
            absorbingMode = false;
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            rb.AddForce(new Vector2(0, 70));

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(thePlatform.absorbBall == false)
        {
            Thespeed = lastVelocity.magnitude + 0.1f * Time.deltaTime;
            var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(Thespeed, 0.1f);
        }

        else if(thePlatform.absorbBall == true)
        {
            Thespeed = lastVelocity.magnitude + 0f * Time.deltaTime;
            var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(Thespeed, 0f);
        }
            
        

       
        
        if(other.gameObject.CompareTag("BlockRed"))
        {
            Destroy(other.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

           int Spawn1 =  Random.Range(0, 8);

            if(Spawn1 == 1)
            {
                
                Instantiate(redPowerUp,new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y,0),Quaternion.identity,transform);
            }

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("BlockBlue"))
        {
            Destroy(other.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

            int Spawn1 = Random.Range(0, 8);

            if (Spawn1 == 1)
            {
                Instantiate(bluePowerUp, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity, transform);
            }
        }

        if (other.gameObject.CompareTag("BlockPink"))
        {
            Destroy(other.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

            int Spawn1 = Random.Range(0, 8);

            if (Spawn1 == 1)
            {
                Instantiate(pinkPowerUp, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity, transform);
            }
        }

        if (other.gameObject.CompareTag("BlockGreen"))
        {
            Destroy(other.gameObject);
            gameController.playerScore += 100;
            gameController.Brick -= 1;

            int Spawn1 = Random.Range(0, 8);

            if (Spawn1 == 1)
            {
                Instantiate(greenPowerUp, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, 0), Quaternion.identity, transform);
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
           
        }

        if (other.gameObject.CompareTag("Gate"))
        {
            SceneManager.LoadScene(1);

        }

        if (other.gameObject.CompareTag("Plat")&& thePlatform.absorbBall == true)
        {
            absorbingMode = true;
            Debug.Log(111);
           
        }

        if (thePlatform.absorbBall == false)
        {
            absorbingMode = false;

        }
    }
}

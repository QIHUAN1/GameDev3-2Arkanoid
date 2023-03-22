using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            rb.AddForce(new Vector2(0, 170));
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
        bool canReset = true;
        if(canReset == true)
        {
            gameController.playerHp -= 1;
            gameController.canShoot = false;
            startGame.Begin();
            canReset = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Thespeed = lastVelocity.magnitude + 0.1f * Time.deltaTime;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(Thespeed, 0.1f);
        if(collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 lastVelocity;

    Rigidbody2D rb;

    GameController gameController;

    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
       
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(0, -100));
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;

        if (transform.position.y < -5)
        {
            gameController.playerHp -= 1;

            Destroy(gameObject);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
       
    }
}

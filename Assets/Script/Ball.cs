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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        lastVelocity = rb.velocity;

        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log(111);
            rb.AddForce(new Vector2(0, 300));
        }


        
        if(transform.position.y < minY)
        {
            ResetBall();
        }

        if(Thespeed > 8)
        {
            Thespeed = 8;
        }


    }


    void ResetBall ()
    {
        //rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Thespeed = lastVelocity.magnitude + 0.1f * Time.deltaTime;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(Thespeed, 0.01f);
        if(collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }
}

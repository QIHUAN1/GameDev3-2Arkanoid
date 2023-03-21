using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float minY;
    public float maxVelo = 15f;

    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rb.velocity.magnitude > maxVelo)
        {
           rb.velocity = Vector3.ClampMagnitude(rb.velocity,maxVelo);
        }


        
        if(transform.position.y < minY)
        {
            ResetBall();
        }
    }

    void ResetBall ()
    {
        //rb.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Player player;
    public Rigidbody2D rb;
    public Vector2 velocity;
    public bool isFaceRight;

    public float distance;

    public float forceX;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
        isFaceRight = player.faceRight;
        //velocity = rb.velocity;
        if(isFaceRight)
        {
            rb.AddForce(new Vector2(forceX, 0), ForceMode2D.Impulse);
            velocity = new Vector2(20, -15);
        }
        else
        {
            rb.AddForce(new Vector2(-forceX, 0), ForceMode2D.Impulse);
            velocity = new Vector2(-20, -15);
        }
        Destroy(gameObject, 2f);
    }

    private void Update()
    {
        if (rb.velocity.y < velocity.y)
        {
            rb.velocity = velocity;
        }

        RaycastHit2D rayHit1 = Physics2D.Raycast(transform.position, Vector2.right, distance);
        Debug.DrawRay(transform.position, Vector2.right * distance);
        if (rayHit1.collider != null && rayHit1.collider.tag == "Ground");
        {
            Debug.Log("check apple");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isFaceRight)
        {
            rb.velocity = new Vector2(velocity.x, -velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(velocity.x, -velocity.y);
        }
        if(collision.gameObject.tag == "Trap")
        {
            Destroy(gameObject);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ExploreCollider")
        {
            Destroy(gameObject);
        }
    }

    public void Explore()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject[] waypoints;


    Rigidbody2D obstacleRigidbody;
    BoxCollider2D obstacleCollider;

    private int i = 0;



    void Start()
    {
        obstacleRigidbody = GetComponent<Rigidbody2D>();
        obstacleCollider = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {
            
        if (Vector2.Distance(transform.position, waypoints[i].transform.position) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[i].transform.position, moveSpeed*Time.deltaTime);
        }
        else
        {
            i++;
            if (i == waypoints.Length)
            {
                i = 0;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            collision.transform.SetParent(transform, true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
        
    }
}

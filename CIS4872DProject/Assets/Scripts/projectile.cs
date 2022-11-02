using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float speed;

    public Vector3 pos;
    private Transform player;
    private Vector2 target;
   // public PlayerMovement playerspeed; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }


    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == pos)
        {
            DestroyProjectile();
        }
        pos = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            DestroyProjectile();
            
        }
        //if (other.CompareTag("Player"))
        //{
        //    playerspeed.speed -= 2f; 
        //}
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.)
    //    {
    //        DestroyProjectile();
    //    }
    //}

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}

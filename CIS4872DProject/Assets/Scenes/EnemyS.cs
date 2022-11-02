using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyS : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public Transform player;
    public GameObject projectile;


    public bool facingRight = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        timeBetweenShots = startTimeBetweenShots;
        
    }


    void Update()
    {

        if (player.transform.position.x > gameObject.transform.position.x && facingRight)
            Flip();
        if (player.transform.position.x < gameObject.transform.position.x && !facingRight)
            Flip();


        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position) > retreatDistance))
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;

        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    void Flip()
    {
        //here your flip funktion, as example
        facingRight = !facingRight;
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x *= -1;
        gameObject.transform.localScale = tmpScale;
    }


}

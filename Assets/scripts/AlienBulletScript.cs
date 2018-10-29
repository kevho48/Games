using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBulletScript : MonoBehaviour
{
    private Vector2 playerPos;
    private Rigidbody2D rb2d;
    
    private Vector2 direction;
    private float speed;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        direction = (playerPos - rb2d.position).normalized;
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.transform.position.x < 10 && rb2d.transform.position.x > -7 && rb2d.transform.position.y > -6 && rb2d.transform.position.y < 6)
        {
            rb2d.position += direction * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    
}

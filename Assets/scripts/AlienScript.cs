using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienScript : MonoBehaviour
{
    public GameObject bullet;
    
    private Rigidbody2D rb2d;
    public Vector2 velocity;
    bool moveUp = true;
    float counter = 0;
    bool dead = false;
    
    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (Random.value < 0.5f)
            moveUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (moveUp)
            {
                rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
                if (rb2d.position.y > 4f)
                    moveUp = false;
            }
            else
            {
                rb2d.MovePosition(rb2d.position - velocity * Time.fixedDeltaTime);
                if (rb2d.position.y < -4f)
                    moveUp = true;
            }

            if (counter >= 1)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                counter = 0;
            }
            else
            {
                counter += Time.deltaTime;
            }
        }
    }
}
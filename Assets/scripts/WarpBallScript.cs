using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpBallScript : MonoBehaviour {
    
    private Rigidbody2D rb2d;
    private Vector2 movement;
    private int counter = 0;
    private bool moveUp = false;
    
    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        if (Random.value < 0.5f)
            moveUp = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (moveUp)
        {
            rb2d.MovePosition(rb2d.position + new Vector2(-3f, 3f) * Time.fixedDeltaTime);
            if (rb2d.position.y > 4f)
                moveUp = false;
        }
        else
        {
            rb2d.MovePosition(rb2d.position + new Vector2(-3f, -3f) * Time.fixedDeltaTime);
            if (rb2d.position.y < -4f)
                moveUp = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBeamScript: MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 velocity;
    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector2(15f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.transform.position.x > -7)
        {
            rb2d.MovePosition(rb2d.position - velocity * Time.fixedDeltaTime);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

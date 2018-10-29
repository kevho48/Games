using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour
{
    public GameObject beam;
    private Vector2 playerPos;
    private Rigidbody2D rb2d;
    private Vector2 velocity;
    float counter;

    private bool action;    //true = move, false = shoot

    // Use this for initialization
    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        action = true;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //move to same y position as player, if same then shoots

        if (counter >= 1)
            action = true;
        else
            counter += Time.deltaTime;

        if (action)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

            rb2d.position += new Vector2(0, playerPos.y - rb2d.position.y) * 10f * Time.deltaTime;
            if (rb2d.position.y > playerPos.y-0.1f && rb2d.position.y < playerPos.y + 0.1f)
            {
                Instantiate(beam, new Vector2(transform.position.x, transform.position.y-1f), Quaternion.identity);
                action = false;
                counter = 0;
            }
        }
    }
}

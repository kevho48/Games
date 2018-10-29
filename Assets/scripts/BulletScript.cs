using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour {
    public delegate void GameDelegate();
    public static event GameDelegate OnPlayerScored;

    public AudioClip clip;

    private Vector2 velocity = new Vector2(13f, 0f);
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb2d.transform.position.x < 10)
        {
            rb2d.MovePosition(rb2d.position + velocity * Time.fixedDeltaTime);
        }
        else {
            Destroy(gameObject);
        }    
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BulletHit")
        {
            //event listener for colliders with tag
            //event sent to game manager
            // print("hit");
            print("E");
            AudioSource.PlayClipAtPoint(clip, new Vector3(5, 1, 2));
            //someSound.Play();
            //  print(someSound);
            Destroy(gameObject);
            col.gameObject.transform.position = new Vector3(-30,0,0);
        }

        if (col.gameObject.tag == "emeny")
        {
            print("F");
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}

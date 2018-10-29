using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

    public delegate void GameDelegate();
    public static event GameDelegate OnPlayerDied;
    public static event GameDelegate OnPlayerScored;
    public static event GameDelegate Ghosting;

    public AudioSource someSound;

    public Vector3 startPos;

    public GameObject bullet;
    public GameObject shieldpic;
    public int cooldowntime = 100;
    public float tapForce = 10;
    public float tiltSmooth = 5;

    private float x;
    private float y;

    public float speed = 10f;

    public bool cooldown = false;
    public int warps = 0;
    public float count = 0;
    private bool shieldbool = false;
    public float shieldtimer = 0;
    private Rigidbody2D rb2d;
    Quaternion downRotation;
    Quaternion forwardRotation;

    public int catLives;

    GameManager game;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0,0,-90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
        game = GameManager.Instance;
        rb2d.simulated = false;
        catLives = 0;

        x = 0;
        y = 0;
    }

    void OnEnable()
    {
        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    void OnDisable()
    {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    void OnGameStarted() {
        rb2d.velocity = Vector3.zero;
        
        rb2d.simulated = true;
    }

    void OnGameOverConfirmed() {
        transform.localPosition = startPos;
        transform.rotation = Quaternion.identity;
        //rigidbody.simulated = false;
    }

    void Update()
    {
        if (game.GameOver) return;
        //if w or the up arrow is pressed, move the player up

        x = Input.GetAxis("Horizontal") * speed;
        y = Input.GetAxis("Vertical") * speed;
        rb2d.MovePosition(rb2d.position + new Vector2(x, y) * Time.fixedDeltaTime);
        
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.JoystickButton1)) && warps > 0)
        {
            rb2d.MovePosition(new Vector2(rb2d.position.x + 6f, rb2d.position.y));
            warps--;
        }

        //if the spacebar is pressed, shoot lemons
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton2) || Input.GetKey(KeyCode.JoystickButton3)) && cooldown == false)
        {
            // print("space being pressed");
            Instantiate(bullet, new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.identity);
           // Instantiate(bullet, transform.position, Quaternion.identity);
            someSound.Play();
            cooldown = true;
            count = 0;
        }

        //prevent player from moving off screen

        if (shieldbool == true)
        {
            shieldtimer += Time.deltaTime;
        }
        if (shieldtimer >= 5)
        {
            shieldpic.GetComponent<SpriteRenderer>().enabled = false;
            shieldpic.GetComponent<CircleCollider2D>().enabled = false;
            shieldbool = false;
            shieldtimer = 0;
        }

        if (count >= cooldowntime)
        {
            cooldown = false;
        }
        else if (count < cooldowntime)
        {
            count += Time.deltaTime;
        }
        Vector2 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -7f, 7.5f);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -4.8f, 4f);
        transform.position = currentPosition;
        Ghosting();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "emeny" && shieldbool == true)
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "ScoreZone") {
            //event listener for colliders with tag
           // OnPlayerScored(); //event sent to game manager
        }
        if (col.gameObject.tag == "DeadZone") {
            //event listener for colliders with tag
            if (shieldbool == true)
            {
                Destroy(col.gameObject);
            }
            else
            {
                if (catLives > 0)
                    catLives--;
                else
                {
                    rb2d.simulated = false;
                    OnPlayerDied(); //event sent to the game manager
                }
            }
        }
        if (col.gameObject.tag == "BulletHit")
        {
            //event listener for colliders with tag
            if (shieldbool == true)
            {
                Destroy(col.gameObject);
            }
            else
            {
                if (catLives > 0)
                {
                    Destroy(col.gameObject);
                    catLives--;
                }
                else
                {
                    rb2d.simulated = false;
                    OnPlayerDied(); //event sent to the game manager
                }
            }
        }
        if (col.gameObject.tag == "WarpBall")
            warps++;

        if (col.gameObject.tag == "ShieldBall")
        {
            shieldpic.GetComponent<SpriteRenderer>().enabled = true;
            shieldpic.GetComponent<CircleCollider2D>().enabled = true;
            shieldbool = true;
        }

        if (gameObject.tag == "AsteroidHit")
        {
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Cat")
        {
            catLives++;
            Destroy(col.gameObject);
        }

        if(gameObject.tag == "emeny")
        {
            rb2d.simulated = false;
            OnPlayerDied();
        }
    }
}
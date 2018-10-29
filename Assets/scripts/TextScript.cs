using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour {

    Text txt;
    private int warp;
    private int lives;

    // Use this for initialization
    void Start()
    {
        lives = GameObject.Find("Griffin").GetComponent<TapController>().catLives;
        warp = GameObject.Find("Griffin").GetComponent<TapController>().warps;
        txt = gameObject.GetComponent<Text>();
        txt.text = "Lives : " + lives + "\n" + "Warps : " + warp;

    }

    // Update is called once per frame
    void Update()
    {
        lives = GameObject.Find("Griffin").GetComponent<TapController>().catLives;
        warp = GameObject.Find("Griffin").GetComponent<TapController>().warps;
        txt.text = "Lives : " + lives + "\n" + "Warps : " + warp;
    }
}

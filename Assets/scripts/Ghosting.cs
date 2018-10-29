using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosting : MonoBehaviour {

    public delegate void GameDelegate();
    public GameObject ghost;
    // Use this for initialization1
    void OnEnable()
    {
        TapController.Ghosting += Ghost;
    }

    void OnDisable()
    {
        TapController.Ghosting -= Ghost;
    }

    void Ghost()
    {
      int warp = GameObject.Find("Griffin").GetComponent<TapController>().warps;
        if (warp > 0)
        {
            //print("Yessss");
            ghost.GetComponent<SpriteRenderer>().enabled = true;

        }
        else
        {
            //print("noooo");
            ghost.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

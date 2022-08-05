using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Movement _movement;
   // private GameObject eight;
    private bool jumping;

   
    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("Slime").GetComponent<Movement>();
        // eight = GameObject.Find("Animaton").transform.GetChild(1).gameObject;
        //eight.SetActive(false);
        jumping = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private bool isjumping(bool jumping)
    {
        if ( _movement.inMidair == true)
        {
            jumping = true;
            return jumping;
           // eight.SetActive(true);
        }
        else
        {
            return false;
        }
    }
}

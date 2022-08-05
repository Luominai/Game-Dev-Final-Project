using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Movement _movement;
    private bool jumping;
   
    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("Slime").GetComponent<Movement>();
        
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
                
        }
        else
        {
            return false;
        }
    }
}

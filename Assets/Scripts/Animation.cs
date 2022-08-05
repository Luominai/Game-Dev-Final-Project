using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Movement _movement;
    private bool walking;
   
    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("Slime").GetComponent<Movement>();
        walking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private bool isWalking(bool walking)
    {
        if ( _movement.pressingD == true || _movement.pressingA == true)
        {
            walking = true;
            return walking;
                
        }
        else
        {
            return false;
        }
    }
}

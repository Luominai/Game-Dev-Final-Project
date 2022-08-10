using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Movement _movement;
 
    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("Animation").transform.GetChild(0).GetComponent<Movement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void isLeftHand()
    {
        if(_movement.leftHandMode == true)
        {
            _movement.leftHandMode = false;
        }
        else
        {
            _movement.leftHandMode = true;
        }
    }
}

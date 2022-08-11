using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private Movement _movement;
    private DataTesting data;
    public Toggle button;
 
    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("Animation").transform.GetChild(0).GetComponent<Movement>();
        data = GameObject.Find("Data").GetComponent<DataTesting>();
        bool F = data.leftHandMode;
        //my guess is that setting isOn is the same as clicking the toggle, which runs isLeftHand(), which sets the bool to false if it is true
        button.isOn = F;
        data.leftHandMode = F;
        _movement.leftHandMode = F;
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

        data.leftHandMode = _movement.leftHandMode;
    }
}

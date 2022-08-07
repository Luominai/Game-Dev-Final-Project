using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Movement _movement;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("slime_8").GetComponent<Movement>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isJumping();
        isWalking();
    }
    private void isJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetBool("jumping", true);
        }
        else
        {
            _animator.SetBool("jumping", false);
        }
    }
    private void isWalking()
    {
        if(_movement.pressingD)
        {
            _animator.SetBool("walking right", true);
        }
        else
        {
            _animator.SetBool("walking right", false) ;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animation : MonoBehaviour
{
    private Movement _movement;
    private Animator _animator;
    private Animator _catanimator;
    private GameObject _cat;
    private GameObject _slime;



    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("slime_8").GetComponent<Movement>();
        _animator = GetComponent<Animator>();
        _slime = GameObject.Find("Animation");
        _catanimator = GameObject.Find("CatAnimation").GetComponent<Animator>();
        _cat = GameObject.Find("CatAnimation");
        _cat.SetActive(false);
        _slime.SetActive(true);  
        

    }

    // Update is called once per frame
    void Update()
    {
        isJumping();
        isWalkingRight();
        isWalkingLeft();
        catjumping();
        
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
    private void isWalkingRight()
    {
        if (_movement.pressingD)
        {
            _animator.SetBool("walking right", true);

        }
        else
        {
            _animator.SetBool("walking right", false);
        }
    }
    private void isWalkingLeft()
    {
        if(_movement.pressingA)
        {
            _animator.SetBool("walking left", true);
        }
        else
        {
            _animator.SetBool("walking left", false);
        }
    }
    private void catjumping()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && Shop.catclicked == true)
        {
            _slime.SetActive(false);
            _catanimator.SetBool("jumping", true);
            print(Shop.catclicked);
        }
        else
        {
            
            _animator.SetBool("jumping", false);

        }
    }

}

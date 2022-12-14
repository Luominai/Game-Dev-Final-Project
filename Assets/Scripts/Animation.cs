using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animation : MonoBehaviour
{
    private Movement _movement;
    private Animator _animator;
    public RuntimeAnimatorController _cat;
    public RuntimeAnimatorController _slime;
    public RuntimeAnimatorController _bow; 
    public CameraMovement _camera;
    private GameObject slimesprite;
    private GameObject catsprite;
    private GameObject bowsprite;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("Game").transform.Find("Animation").transform.Find(Settings.name).GetComponent<Movement>();
        _animator = GetComponent<Animator>();
        _camera = GameObject.Find("CameraController").GetComponent<CameraMovement>();
        slimesprite = GameObject.Find("Game").transform.Find("Animation").transform.Find("slime_8").gameObject;
        catsprite = GameObject.Find("Game").transform.Find("Animation").transform.Find("cat_10").gameObject;
        bowsprite = GameObject.Find("Game").transform.Find("Animation").transform.Find("bow_0").gameObject;
        cameracat();


    }

    // Update is called once per frame
    void Update()
    {
        isJumping();
        isWalkingRight();
        isWalkingLeft();

    
        
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
    private void cameracat()
    {
        print(Shop.catequipped);
        if(Shop.catequipped == true)
        {
            slimesprite.SetActive(false);
            bowsprite.SetActive(false);  
            _camera.player = catsprite;
            _animator.runtimeAnimatorController = _cat; 
        }
        else if (Shop.bowequipped == true)
        {
            //put code to equip bow costume here
            slimesprite.SetActive(false);
            bowsprite.SetActive(true);
            catsprite.SetActive(false);  
            _camera.player = bowsprite;
            _animator.runtimeAnimatorController = _bow;
        }
        else
        {
            slimesprite.SetActive(true);
            catsprite.SetActive(false);
            bowsprite.SetActive(false);
            _camera.player = slimesprite;
            _animator.runtimeAnimatorController = _slime;

        }
    }
   
  

}

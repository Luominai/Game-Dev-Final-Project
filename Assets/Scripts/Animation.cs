using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Movement _movement;
    private Animator _animator;
    private SpriteRenderer _spriterenderer;
    public Sprite _sprite;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GameObject.Find("slime_8").GetComponent<Movement>();
        _animator = GetComponent<Animator>();
        _spriterenderer = GameObject.Find("slime_8").GetComponent<SpriteRenderer>();

      
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
        if (_movement.pressingD)
        {
            _spriterenderer.sprite = _sprite;
        }
    }

}

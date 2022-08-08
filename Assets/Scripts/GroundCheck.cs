using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D footCollider;
    public bool inMidair;
    private Animator _animator;

    void Start()
    {
        _animator = GameObject.Find("Animation").GetComponent<Animator>();
        footCollider = GetComponent<Collider2D>();
        inMidair = true;
    }

    // Update is called once per frame
    void Update()
    {
        //print(inMidair);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Physics2D.IgnoreCollision(footCollider, collision.gameObject.GetComponent<Collider2D>());
        }
        if (collision.gameObject.CompareTag("Ground")) {
            inMidair = false;
            _animator.SetBool("jumping", false);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(footCollider, collision.gameObject.GetComponent<Collider2D>());
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            inMidair = true;
            _animator.SetBool("jumping", false);
        }
    }
}

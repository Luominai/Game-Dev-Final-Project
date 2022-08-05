using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D footCollider;
    private bool isMidair;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        return isMidair;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Physics2D.IgnoreCollision(footCollider, collision.gameObject.GetComponent<Collider2D>());
        }
        if (collision.gameObject.CompareTag("Ground")) {
            isMidair = false;
        } else
        {
            isMidair = true;
        }
    }
}

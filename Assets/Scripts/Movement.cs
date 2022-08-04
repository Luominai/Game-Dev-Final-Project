using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private float xVelocity = 0;
    private float yVelocity = 0;
    private float timeLeft = 0;
    private Rigidbody rigidbody;
    private bool inMidair;

    public float speed = 3f;
    public float timer = .5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = rigidbody.velocity.x;
        yVelocity = rigidbody.velocity.y;
        horizontalMovement();
        dashAndJump();
        //print(movingLeft + ", " + movingRight);
        //print(Input.GetAxis("Horizontal"));
    }

    void horizontalMovement()
    {
        var axis = Input.GetAxis("Horizontal");
        int input = 0;

        if (Input.GetKey(KeyCode.A) && axis < 0)
        {
            input = -1;
        }
        if (Input.GetKey(KeyCode.D) && axis > 0)
        {
            input = 1;
        }

        //if pressing A
        if (input < 0)
        {
            //if you are moving slower than the base, set your velocity to that base speed. Direction of velocity is right
            if (Mathf.Abs(xVelocity) < speed)
            {
                rigidbody.velocity = new Vector3(-1 * speed, yVelocity, 0);
            }
            else
            //changes direction while keeping velocity if you were previously moving right
            {
                rigidbody.velocity = new Vector3(Mathf.Abs(xVelocity) * -1, yVelocity, 0);
            }
        }
        //if pressing D
        if (input > 0)
        {
            //if you are moving slower than the base, set your velocity to that base speed. Direction of velocity is left
            if (Mathf.Abs(xVelocity) < speed)
            {
                rigidbody.velocity = new Vector3(speed, yVelocity, 0);
            }
            else
            //changes direction while keeping velocity if you were previously moving left
            {
                rigidbody.velocity = new Vector3(Mathf.Abs(xVelocity), yVelocity, 0);
            }
        }
    }

    void dashAndJump()
    {
        //if you left click and your boost is off cooldown
        if (Input.GetKeyDown(KeyCode.Mouse0) && timeLeft <= 0)
        {
            //determine which direction to add the force
            float sign = Mathf.Abs(xVelocity) / xVelocity;
            //add a force in that direction
            rigidbody.AddForce(new Vector3(sign * 10, 0, 0), ForceMode.Impulse);
            timeLeft = timer;
        }

        //if you hit space
        if (Input.GetKeyDown(KeyCode.Space) && !inMidair)
        {
            //add a focre upwards. Magnitude scales on speed
            rigidbody.AddForce(new Vector3(0, speed * 2, 0), ForceMode.Impulse);
            //prevent jumping in midair
            inMidair = true;
        }

        //makes timer count down
        timeLeft -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        inMidair = false;
    }
}

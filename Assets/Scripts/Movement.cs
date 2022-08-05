using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    private float xVelocity = 0;
    private float yVelocity = 0;
    private float timeLeft = 0;
<<<<<<< Updated upstream
    private Rigidbody2D rigidbody;
    private bool inMidair;
=======
    private Rigidbody rigidbody;
    public bool inMidair;
>>>>>>> Stashed changes
    string axisName = "Horizontal";

    public float speed = 3f;
    public float dashCD = .5f;
    public bool leftHandMode = false;

    public bool pressingW;
    public bool pressingA;
    public bool pressingS;
    public bool pressingD;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (leftHandMode)
        {
            axisName = "HorizontalLeft";
        }
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = rigidbody.velocity.x;
        yVelocity = rigidbody.velocity.y;
        if (leftHandMode)
        {
            pressingW = Input.GetKey(KeyCode.I);
            pressingA = Input.GetKey(KeyCode.J);
            pressingS = Input.GetKey(KeyCode.K);
            pressingD = Input.GetKey(KeyCode.L);
        } else
        {
            pressingW = Input.GetKey(KeyCode.W);
            pressingA = Input.GetKey(KeyCode.A);
            pressingS = Input.GetKey(KeyCode.S);
            pressingD = Input.GetKey(KeyCode.D);
        }
        horizontalMovement();
        dash();
        jump();
        //print(movingLeft + ", " + movingRight);
        //print(Input.GetAxis("Horizontal"));
    }

    void horizontalMovement()
    {
        var axis = Input.GetAxis(axisName);

        int input = 0;
        if (pressingA && axis < 0)
        {
            input = -1;
        }
        if (pressingD && axis > 0)
        {
            input = 1;
        }

        if (input < 0)
        {
            //if you are moving slower than the base, set your velocity to that base speed. Direction of velocity is right
            if (Mathf.Abs(xVelocity) < speed)
            {
                rigidbody.velocity = new Vector2(-1 * speed, yVelocity);
            }
            else
            //changes direction while keeping velocity if you were previously moving right
            {
                rigidbody.velocity = new Vector2(Mathf.Abs(xVelocity) * -1, yVelocity);
            }
        }

        if (input > 0)
        {
            //if you are moving slower than the base, set your velocity to that base speed. Direction of velocity is left
            if (Mathf.Abs(xVelocity) < speed)
            {
                rigidbody.velocity = new Vector2(speed, yVelocity);
            }
            else
            //changes direction while keeping velocity if you were previously moving left
            {
                rigidbody.velocity = new Vector2(Mathf.Abs(xVelocity), yVelocity);
            }
        }
    }

    void dash()
    {
        float xComponent = 0;
        float yComponent = 0;

        //if you left click and your boost is off cooldown
        if (Input.GetKeyDown(KeyCode.Mouse0) && timeLeft <= 0)
        {
            //determine which direction to add the force
            if (pressingW)
            {
                yComponent += 1;
            }
            if (pressingA)
            {
                xComponent += -1;
            }
            if (pressingS)
            {
                yComponent += -1;
            }
            if (pressingD)
            {
                xComponent += 1;
            }
            //add a force in that direction
            rigidbody.velocity += (new Vector2(xComponent * 5, yComponent * 5));
            //resets timer
            timeLeft = dashCD;
        }
        //makes timer count down
        timeLeft -= Time.deltaTime;
    }

    void jump()
    {
        //if you hit space
        if (Input.GetKeyDown(KeyCode.Space) && !inMidair)
        {
            //add a force upwards. Magnitude scales on speed
            rigidbody.AddForce(new Vector2(0, speed * 2), ForceMode2D.Impulse);
            //prevent jumping in midair
            inMidair = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            inMidair = false;
        }
        print(collision.gameObject.name + " has tag " + collision.gameObject.tag);
    }
}

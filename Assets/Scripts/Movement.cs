using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public string nextLevelName;
    
    private float xVelocity = 0;
    private float yVelocity = 0;
    private float _CDTimer = 0;
    private float _dashTimer = 0;

    private Rigidbody2D rigidbody;
    public GameObject currentCheckpoint = null;
    public bool inMidair;
    public bool isDashing;
    public bool dashEnded;
    private bool isCurrentlyDying = false;

    string axisName = "Horizontal";

    public float speed;
    public float dashCD;
    public float dashDistance;
    public float dashDuration;
    public float gravity;
    public float jumpHeight;
    public float airDashLimit;
    public float airDashesLeft;
    public PhysicsMaterial2D material;
    public bool leftHandMode = false;

    public bool pressingW;
    public bool pressingA;
    public bool pressingS;
    public bool pressingD;

    private Animator _animator;
    private DataTesting data;

    void Start()
    {
        data = GameObject.Find("Data").GetComponent<DataTesting>();
        leftHandMode = data.leftHandMode;
        rigidbody = GetComponent<Rigidbody2D>();
        if (leftHandMode)
        {
            axisName = "HorizontalLeft";
        }

        _animator = GameObject.Find("Animation").GetComponent<Animator>();
        airDashesLeft = airDashLimit;
    }

    // Update is called once per frame
    void Update()
    {
        xVelocity = rigidbody.velocity.x;
        yVelocity = rigidbody.velocity.y;
        inMidair = transform.Find("GroundCheck").GetComponent<GroundCheck>().inMidair;

        if (leftHandMode)
        {
            axisName = "HorizontalLeft";
            pressingW = Input.GetKey(KeyCode.I);
            pressingA = Input.GetKey(KeyCode.J);
            pressingS = Input.GetKey(KeyCode.K);
            pressingD = Input.GetKey(KeyCode.L);
        } else
        {
            axisName = "Horizontal";
            pressingW = Input.GetKey(KeyCode.W);
            pressingA = Input.GetKey(KeyCode.A);
            pressingS = Input.GetKey(KeyCode.S);
            pressingD = Input.GetKey(KeyCode.D);
        }
        horizontalMovement();
        dash();
        bounce();
        jump();
        //print(movingLeft + ", " + movingRight);
        //print(Input.GetAxis("Horizontal"));
    }

    void horizontalMovement()
    {
        //set velocity to 0 once when your dash ends
        if (dashEnded)
        {
            xVelocity = 0;
            yVelocity = 0;
            dashEnded = false;
        }
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
            else if (!isDashing)
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
            else if (!isDashing)
            //changes direction while keeping velocity if you were previously moving left
            {
                rigidbody.velocity = new Vector2(Mathf.Abs(xVelocity), yVelocity);
            }
        }

        if (input == 0 && !isDashing)
        {
            rigidbody.velocity = new Vector2(0, yVelocity);
        }
    }

    void dash()
    {
        float xComponent = 0;
        float yComponent = 0;

        if (!inMidair && !isDashing)
        {
            airDashesLeft = airDashLimit;
        }

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

        if (_dashTimer <= 0)
        {
            //arbitrary interval
            if (_dashTimer >= -.1)
            {
                dashEnded = true;
            }
            isDashing = false;
            rigidbody.gravityScale = 2;
        }

        //if you left click and your boost is off cooldown
        if (Input.GetKeyDown(KeyCode.Mouse0) && _CDTimer <= 0 && !(xComponent == 0 && yComponent == 0) && airDashesLeft > 0)
        {
            airDashesLeft--;
            isDashing = true;
            //create a vector in that direction
            rigidbody.velocity = (new Vector2(xComponent * (dashDistance / dashDuration) * 3, yComponent * (dashDistance / dashDuration) * 3));
            //puts the dash on CD
            _CDTimer = dashCD;
            //starts counting the dash duration
            _dashTimer = dashDuration;
            //negates gravity during the duration of the dash
            rigidbody.gravityScale = 0;
        }
        //makes CD count down
        _CDTimer -= Time.deltaTime;
        //makes dash duration count down
        _dashTimer -= Time.deltaTime;

    }

    void jump()
    {
        //if you hit space
        if (Input.GetKeyDown(KeyCode.Space) && !inMidair)
        {
            //add a force upwards. Magnitude scales on speed
            rigidbody.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            _animator.SetBool("jumping", true);
        }
       
    }

    void bounce()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            rigidbody.sharedMaterial.bounciness = 0.8f;
        } else
        {
            rigidbody.sharedMaterial.bounciness = 0;
        }
        rigidbody.sharedMaterial = material;
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Death") || collision.CompareTag("Enemy")) && !isCurrentlyDying)
        {
            //begin the dying routine
            isCurrentlyDying = true;
            //play the death animation
            //teleport the player to the last checkpoint
            gameObject.transform.position = currentCheckpoint.transform.GetChild(0).position;
            isCurrentlyDying = false;
        }
        if (collision.CompareTag("Checkpoint"))
        {
            if (currentCheckpoint == null || collision.transform.GetSiblingIndex() > currentCheckpoint.transform.GetSiblingIndex())
            {
                print("Set checkpoint!");
                currentCheckpoint = collision.gameObject;
            }
        }

        if (collision.CompareTag("Goal"))
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}

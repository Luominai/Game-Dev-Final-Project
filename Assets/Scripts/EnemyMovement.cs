using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Color horizontalRayColor = Color.green;
    private Color verticalRayColor = Color.green;
    private Color backRayColor = Color.green;
    private Color midRayColor = Color.green;
    private Color frontRayColor = Color.green;
    private Vector3 direction;
    public float speed;
    public float horizontalRayDistance;
    public float verticalRayDistance;
    public float backRayDistance;
    public float gravity;
    public bool startLeft;
    public bool printGroundChecks;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = gravity;
        direction = Vector3.right;
        if (startLeft)
        {
            changeDirection();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, direction * horizontalRayDistance, horizontalRayColor); //forward
        Debug.DrawRay(transform.position + direction * .75f, Vector3.down * verticalRayDistance, verticalRayColor); //cliff
        Debug.DrawRay(transform.position - direction * .6f, Vector3.down * backRayDistance, backRayColor); //back
        Debug.DrawRay(transform.position, Vector3.down * backRayDistance, midRayColor); //mid
        Debug.DrawRay(transform.position + direction * .6f, Vector3.down * backRayDistance, frontRayColor); //front
        horizontalMovement();
        drop();

        if (printGroundChecks)
        {
            print("Behind: " + groundBehind() + " | " + "Below: " + groundBelow() + " | " + "Ahead: " + groundAhead() + " |");
            printGroundChecks = false;
        }
    }

    void horizontalMovement()
    {
        if (!wallAhead())
        {
            rigidbody.velocity = direction * speed;
        }
        turnAround();
    }

    bool wallAhead()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, horizontalRayDistance);
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Ground") || ray.collider.CompareTag("Enemy"))
            {
                horizontalRayColor = Color.red;
                return true;
            } 
        }
        horizontalRayColor = Color.green;
        return false;
    }

    bool cliffAhead()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + direction * .75f, Vector3.down, verticalRayDistance);
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Ground"))
            {
                verticalRayColor = Color.red;
                return false;
            }
        }
        verticalRayColor = Color.green;
        return true;
    }

    bool groundBehind()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position - direction * .6f, Vector3.down, backRayDistance);
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Ground") || ray.collider.CompareTag("Enemy"))
            {
                backRayColor = Color.green;
                return true;
            }
        }
        backRayColor = Color.red;
        return false;
    }
    bool groundAhead()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position + direction * .6f, Vector3.down, backRayDistance);
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Ground") || ray.collider.CompareTag("Enemy"))
            {
                frontRayColor = Color.green;
                return true;
            }
        }
        frontRayColor = Color.red;
        return false;
    }

    bool groundBelow()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector3.down, backRayDistance);
        if (ray.collider != null)
        {
            if (ray.collider.CompareTag("Ground") || ray.collider.CompareTag("Enemy"))
            {
                midRayColor = Color.green;
                return true;
            }
        }
        midRayColor = Color.red;
        return false;
    }

    void turnAround()
    {
        if (cliffAhead() || wallAhead())
        {
            changeDirection();
        }
    }

    void changeDirection()
    {
        if (direction.Equals(Vector3.left))
        {
            direction = Vector3.right;
        } else 
        if (direction.Equals(Vector3.right))
        {
            direction = Vector3.left;
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
    }

    void drop()
    {
        //I tried just putting them in an if loop but it kept short circuiting so I put them here instead
        bool behind = groundBehind();
        bool below = groundBelow();
        bool ahead = groundAhead();
        if (!behind && !below && !ahead)
        {
            rigidbody.AddForce(Vector2.down * 10, ForceMode2D.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Color horizontalRayColor = Color.green;
    private Color verticalRayColor = Color.green;
    private Vector3 direction;
    public float speed;
    public float horizontalRayDistance;
    public float verticalRayDistance;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = gravity;
        direction = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, direction * horizontalRayDistance, horizontalRayColor);
        Debug.DrawRay(transform.position + direction * .5f, Vector3.down * verticalRayDistance, verticalRayColor);
        horizontalMovement();
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, direction, horizontalRayDistance, 3);
        if (ray.collider != null)
        {
            string[] layer = { "Ground" };
            if (ray.collider.CompareTag("Ground"))
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
        RaycastHit2D ray = Physics2D.Raycast(transform.position + direction * .5f, Vector3.down, verticalRayDistance, 3);
        if (ray.collider != null)
        {
            string[] layer = { "Ground" };
            if (ray.collider.CompareTag("Ground"))
            {
                verticalRayColor = Color.green;
                return false;
            }
        }
        verticalRayColor = Color.red;
        return true;
    }

    void turnAround()
    {
        if (cliffAhead() || wallAhead())
        {
            changeDirection();
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z);
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
    }
}

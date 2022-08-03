using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public float gravity = 1f;
    Rigidbody rigidbody;
    float x;
    float y;
    public float timer = .5f;
    float timeLeft = 0;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && timeLeft <= 0)
        {
            rigidbody.AddForce(new Vector3(Mathf.Abs(x) / x * 10, 0, 0), ForceMode.Impulse);
            timeLeft = timer;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector3(0, gravity * 2, 0), ForceMode.Impulse);
        }

        timeLeft -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        x = rigidbody.velocity.x;
        y = rigidbody.velocity.y;
        rigidbody.AddForce(Vector3.down * gravity * rigidbody.mass);
        horizontalMovement();
    }

    void horizontalMovement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (Mathf.Abs(x) < speed)
            {
                rigidbody.velocity = new Vector3(speed, y, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (Mathf.Abs(x) < speed)
            {
                rigidbody.velocity = new Vector3(-speed, y, 0);
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(0, y);
        }
    }
}

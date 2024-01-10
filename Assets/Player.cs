using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed;
    Rigidbody2D rb;
    enum Direction
    {
        north, south, west, east
    }
    Direction movingDir;
    //bool movingHorizontally, canCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
        */
        /*
        if (movingHorizontally)
        {
            if (Physics2D.Raycast(transform.position, Vector2.left, .6f))
            {
                canCheck = true;
            }
            else
            {
                canCheck= false;
            }
        }
        */
        //if (canCheck) 
        //{
            if (Input.GetAxisRaw("Horizontal") !=0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    movingDir = Direction.east;
                }
                else
                {
                    movingDir = Direction.west;
                }

            }
            else if (Input.GetAxisRaw("Vertical") !=0)
            {
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;

                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    movingDir = Direction.north;
                }
                else
                {
                    movingDir = Direction.south;
                }
        }
        //}
    }

    void FixedUpdate()
    {
        switch (movingDir)
        {
            case Direction.north:
                rb.velocity = new Vector2(0, moveSpeed * Time.fixedDeltaTime);
                break;
            case Direction.south:
                rb.velocity = new Vector2(0, -moveSpeed * Time.fixedDeltaTime);
                break;
            case Direction.west:
                rb.velocity = new Vector2(-moveSpeed * Time.fixedDeltaTime,0);
                break;
            case Direction.east:
                rb.velocity = new Vector2(moveSpeed * Time.fixedDeltaTime, 0);
                break;
            default:
                break;
        }
    }
}

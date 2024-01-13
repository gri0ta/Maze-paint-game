using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Direction
{
    Up,Down,Left,Right,None
}
public class Playerr : MonoBehaviour
{
    public float speed;
    public Direction direction;
    Rigidbody2D rb;
    Collider2D leftCollider;
    Collider2D rightCollider;
    Collider2D topCollider;
    Collider2D bottomCollider;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        var colliders = new List<Collider2D>();
        rb.GetAttachedColliders(colliders);

        foreach (var collider in colliders)
        {
            if (collider.offset.x == 0) //bottom arba top colliders
            {
                if (collider.offset.y >0) //kaip gauti colliderio kintamaji nehackinant?
                {
                    topCollider = collider;
                }
                else
                {
                    bottomCollider= collider;
                }
            }
            else
            {
                if (collider.offset.x > 0)
                {
                    rightCollider = collider;
                }
                else
                {
                    leftCollider= collider;
                }
            }

        }
    }


    void Update()
    {
        // Reset movement each frame
        Vector2 movement = Vector2.zero;

        // Check for button presses
        if (Input.GetKey(KeyCode.W)) // Move Up
        {
            
            this.direction = Direction.Up;
        }
        else if (Input.GetKey(KeyCode.S)) // Move Down
        {
            
            this.direction = Direction.Down;
        }
        else if (Input.GetKey(KeyCode.A)) // Move Left
        {
            this.direction = Direction.Left;
        }
        else if (Input.GetKey(KeyCode.D)) // Move Right
        {
            this.direction = Direction.Right;
        }

        switch (this.direction)
        {
            case Direction.Up:
                if (!topCollider.IsTouchingLayers())
                {
                    movement = Vector2.up;
                }
                
                break;
            case Direction.Down:
                if (!bottomCollider.IsTouchingLayers())
                {
                    movement = Vector2.down;
                }
               
                break;
            case Direction.Left:
                if (!leftCollider.IsTouchingLayers())
                {
                    movement = Vector2.left;
                }
                break;
            case Direction.Right:
                if (!rightCollider.IsTouchingLayers())
                {
                    movement = Vector2.right;
                }
                break;
            default:
                break;
        }

        
        
        movement = movement.normalized * speed * Time.deltaTime;

        // Apply movement to the player
        transform.Translate(movement);
    }
}

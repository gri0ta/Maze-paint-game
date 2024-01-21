using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;
using UnityEngine.Networking;
using UnityEngine.UIElements;
using System.Drawing;
using Color = UnityEngine.Color;

public enum Direction
{
    Up,Down,Left,Right,None
}
public class Playerr : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase newTile;

    public float cycleLength;
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
        

        
        if (Input.GetKey(KeyCode.W))
        {
            
            this.direction = Direction.Up;
        }
        else if (Input.GetKey(KeyCode.S)) 
        {
            
            this.direction = Direction.Down;
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            this.direction = Direction.Left;
        }
        else if (Input.GetKey(KeyCode.D)) 
        {
            this.direction = Direction.Right;
        }

        switch (this.direction)
        {
            case Direction.Up:
                if (!topCollider.IsTouchingLayers())
                {
                    movement = Vector2.up;
                    //movement = transform.DOMove(new Vector2(0, 10), cycleLength);
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


        Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

        TileBase tile = tilemap.GetTile(cellPosition);

        if (tile != null)
        {
            tilemap.SetColor(cellPosition, Color.red);
            //ChangeTileColor(cellPosition, newTile);
        }

        tilemap.SetTileFlags(cellPosition, TileFlags.None);

        movement = movement.normalized * speed * Time.deltaTime;

        // Apply movement to the player
        transform.Translate(movement);
    }

    void ChangeTileColor(Vector3Int cellPosition, TileBase newTile) //pakeicia single tile color arba texture
    {
        tilemap.SetTile(cellPosition, newTile);
    }
}

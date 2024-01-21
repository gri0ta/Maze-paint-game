using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
public class Movement : MonoBehaviour
{
    public float cycleLenght;
    public Direction direction;
    

    void Update() { 

    var map = FindObjectOfType<Tilemap>();
    // tilebase
    var tilePos = map.WorldToCell(transform.position); //tilePos duoda kurioje koordinateje yra playeris
                                                       //print(tilePos);
    var tile = map.GetTile(tilePos); //duoda ar null tile ant kurio stovime
            //print(tile);
    
        if (Input.GetKey(KeyCode.W)) //Up
        {
            this.direction = Direction.Up;
            
            if (tile == null)
            {
                tilePos.x += 1;
                print("tile is null");
                transform.DOMove(new Vector2(0, 10), cycleLenght);
                
            }
            else
            {
                
                print("tile isnt null");
            }
            
        }
        else if (Input.GetKey(KeyCode.S)) //Down
        {
            this.direction = Direction.Down;
            
            if (tile == null)
            {
                tilePos.x -= 1;
                //print("tile is null");
                transform.DOMove(new Vector2(0, -10), cycleLenght);
            }

        }
        else if (Input.GetKey(KeyCode.A)) //Left
        {
            this.direction = Direction.Left;
            

            
            if (tile == null)
            {
                tilePos.y += 1;
                //print("tile is null");
                transform.DOMove(new Vector2(-10, 0), cycleLenght);
            }
        }
        else if (Input.GetKey(KeyCode.D)) //Right
        {
            this.direction = Direction.Right;
            

            
            if (tile == null)
            {
                tilePos.y -= 1;
                //print("tile is null");
                transform.DOMove(new Vector2(10, 0), cycleLenght);
            }
        }
    }

    
}

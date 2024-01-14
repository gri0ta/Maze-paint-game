using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;
public class Movement : MonoBehaviour
{
    public float cycleLenght = 0.5f;
    /*
    public void Collision()
    {
        // check if grid cell is not empty at player position

        var map = FindObjectOfType<Tilemap>();
        // tilebase

        var tilePos = map.WorldToCell(transform.position);
        var tile = map.GetTile(tilePos);
    }
    */

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //Up
        {
            var map = FindObjectOfType<Tilemap>();
            // tilebase
            var tilePos = map.WorldToCell(transform.position); //tilePos duoda kurioje koordinateje yra playeris
            //print(tilePos);
            var tile = map.GetTile(tilePos); //duoda ar null tile ant kurio stovime
            //print(tile);
       
            //tilePos.x += 1;
            if (tile == null)
            {
                //print("tile is null");
                transform.DOMove(new Vector3(0, 10, 0), cycleLenght);
            }
            
        }
        else if (Input.GetKey(KeyCode.S)) //Down
        {
            var map = FindObjectOfType<Tilemap>();
            // tilebase
            var tilePos = map.WorldToCell(transform.position); //tilePos duoda kurioje koordinateje yra playeris
            //print(tilePos);
            var tile = map.GetTile(tilePos); //duoda ar null tile ant kurio stovime
                                             //print(tile);

            //tilePos.x += 1;
            if (tile == null)
            {
                //print("tile is null");
                transform.DOMove(new Vector3(0, -10, 0), cycleLenght);
            }

        }
        else if (Input.GetKey(KeyCode.A)) //Left
        {
            var map = FindObjectOfType<Tilemap>();
            // tilebase
            var tilePos = map.WorldToCell(transform.position); //tilePos duoda kurioje koordinateje yra playeris
            //print(tilePos);
            var tile = map.GetTile(tilePos); //duoda ar null tile ant kurio stovime
                                             //print(tile);

            //tilePos.x += 1;
            if (tile == null)
            {
                //print("tile is null");
                transform.DOMove(new Vector3(-10, 0, 0), cycleLenght);
            }
        }
        else if (Input.GetKey(KeyCode.D)) //Right
        {
            var map = FindObjectOfType<Tilemap>();
            // tilebase
            var tilePos = map.WorldToCell(transform.position); //tilePos duoda kurioje koordinateje yra playeris
            //print(tilePos);
            var tile = map.GetTile(tilePos); //duoda ar null tile ant kurio stovime
                                             //print(tile);

            //tilePos.x += 1;
            if (tile == null)
            {
                //print("tile is null");
                transform.DOMove(new Vector3(10, 0, 0), cycleLenght);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerr : MonoBehaviour
{
    public float speed = 5f; // Adjust this to set the player's movement speed

    void Update()
    {
        // Reset movement each frame
        Vector3 movement = Vector3.zero;

        // Check for button presses
        if (Input.GetKey(KeyCode.W)) // Move Up
        {
            movement += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S)) // Move Down
        {
            movement += Vector3.down;
        }
        if (Input.GetKey(KeyCode.A)) // Move Left
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D)) // Move Right
        {
            movement += Vector3.right;
        }

        // Normalize the movement vector (to prevent faster diagonal movement)
        movement = movement.normalized * speed * Time.deltaTime;

        // Apply movement to the player
        transform.Translate(movement);
    }
}

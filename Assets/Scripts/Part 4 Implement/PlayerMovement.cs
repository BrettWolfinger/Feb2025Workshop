using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Vector2 movementValue;

    public void OnMove(InputValue value)
    {
        movementValue = value.Get<Vector2>()*speed;
    }

    void Update()
    {

        transform.Translate(movementValue.x*Time.deltaTime, movementValue.y*Time.deltaTime, 0);
        
        // Get mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Calculate direction vector from prefab to mouse
        Vector3 direction = mousePosition - transform.position;
        // Set rotation to face the mouse (only rotate on the Z-axis in 2D)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; //offset by 90 to align with y

        transform.rotation = Quaternion.Euler(0, 0, angle);
        Debug.DrawLine(transform.position,mousePosition,Color.white,Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFiveAngleControler : MonoBehaviour
{
    public Transform customPivot; // Assign the pivot point in the Unity Editor
    private Vector3 initialMousePosition;
    public bool isInverted = false;
    public bool isActive = true;
    public bool isStable = false;

    private void Start()
    {
        
    }

    void Update()
    {

        if (isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // Reset the initial mouse position when dragging stops
                initialMousePosition = Vector3.zero;
            }

            if (Input.GetMouseButton(0) && initialMousePosition != Vector3.zero)
            {
                // Get the vertical movement of the mouse
                float mouseX = Input.mousePosition.x - initialMousePosition.x;

                mouseX *= -.1f;
                Vector3 move = Vector3.forward;
                if (isInverted) { move = Vector3.back; mouseX *= 2; }
                if (isStable) { move = Vector3.forward; mouseX *= -1; }


                if (customPivot != null)
                {
                transform.RotateAround(customPivot.transform.position, move, mouseX);

                }
                // Set the object's rotation to match the y position of the mouse around the custom pivot point
                else
                {
                transform.RotateAround(transform.position, move, mouseX);
                }

                // Update the initial mouse position for the next frame
                initialMousePosition = Input.mousePosition;
            }

        }



    }
}

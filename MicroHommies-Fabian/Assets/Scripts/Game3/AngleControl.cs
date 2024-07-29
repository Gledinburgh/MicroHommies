using UnityEngine;

public class AngleControl : MonoBehaviour
{
    public Transform customPivot; // Assign the pivot point in the Unity Editor
    private Vector3 initialMousePosition;
    public bool isActive = true;
    public AngleTracker angleTracker;

    private void Start()
    {
        angleTracker = FindObjectOfType<AngleTracker>();
    }

    void Update()
    {

        if (angleTracker.maxAngleReached)
        {
            transform.RotateAround(customPivot.position, Vector3.forward, 1);
        }

        else
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
                float mouseY = Input.mousePosition.y - initialMousePosition.y;

                mouseY *= -.1f;

                // Set the object's rotation to match the y position of the mouse around the custom pivot point
                transform.RotateAround(customPivot.position, Vector3.forward, mouseY);

                // Update the initial mouse position for the next frame
                initialMousePosition = Input.mousePosition;
            }

        }


        }
    }
}

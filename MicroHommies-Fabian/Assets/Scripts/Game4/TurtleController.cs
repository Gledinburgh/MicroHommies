using UnityEngine;

public class TurtleController : MonoBehaviour
{
    // Store the initial rotation
    private Quaternion initialRotation;

    // Set the threshold for the rotation (180 degrees)
    private float rotationThreshold = 180f;

    // Store the total rotation angle
    private float totalRotation = 0f;

    // Flag to indicate if rotation is allowed
    private bool canRotate = true;

    void Start()
    {
        // Store the initial rotation
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Check if rotation is allowed
        if (!canRotate)
            return;

        // Check for mouse button down to start rotation
        if (Input.GetMouseButtonDown(0))
        {
            initialRotation = transform.rotation;
        }

        // Check for mouse button held down to continue rotation
        if (Input.GetMouseButton(0))
        {
            // Calculate the mouse movement direction
            float mouseDeltaY = Input.GetAxis("Mouse Y");

            // Calculate rotation angle based on mouse movement
            float rotationAngle = -mouseDeltaY * 100f; // Adjust rotation sensitivity as needed

            // Apply rotation to the turtle
            transform.Rotate(Vector3.back, rotationAngle);

            // Update total rotation angle
            totalRotation += Mathf.Abs(rotationAngle);

            // Check if the total rotation exceeds the threshold
            if (totalRotation >= rotationThreshold)
            {
                // Disable further rotation
                canRotate = false;

                // Turtle has flipped 180 degrees, trigger win condition
                Debug.Log("Turtle flipped 180 degrees! You win!");

                // Trigger win condition in MicrogameManager4
               // FindObjectOfType<MicrogameManager4>().Win();
            }
        }
    }
}

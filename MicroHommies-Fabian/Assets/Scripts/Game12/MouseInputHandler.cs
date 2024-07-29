// MouseInputHandler.cs
using UnityEngine;

public class MouseInputHandler : MonoBehaviour
{
    private Vector3 initialMousePosition;
    private bool isDragging = false;

    void Update()
    {
        
    }


    public void UpdateMouse()

    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mouseDelta = Input.mousePosition - initialMousePosition;
            float movementSpeed = 1f; // Adjust as needed
            transform.Translate(Vector3.up * mouseDelta.y * movementSpeed * Time.deltaTime);
            initialMousePosition = Input.mousePosition;
        }
    }

}
using UnityEngine;

public class ObjectControllerX : MonoBehaviour
{
    public float speed = 1f; // Adjust this to control the speed of the player
    private bool hasCollided = false;
    private Vector3 initialMousePosition;
    private bool isDragging = false;

    void Update()
    {
        if (!hasCollided)
        {
            // Left and right movement
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

            // Mouse input handling
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
                transform.Translate(Vector3.right * mouseDelta.x * speed * Time.deltaTime);
                initialMousePosition = Input.mousePosition;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!");
            hasCollided = true;
            // Optionally, you can add more actions here such as stopping the movement of the player
        }
    }
}

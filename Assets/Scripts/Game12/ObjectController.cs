using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed = 1f; // Adjust this to control the speed of the finger
    private bool hasCollided = false;
    private Vector3 initialMousePosition;
    private bool isDragging = false;

    void Update()
    {
        if (!hasCollided)
        {
            // Arrow key movement
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

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
                transform.Translate(Vector3.up * mouseDelta.y * speed * Time.deltaTime);
                initialMousePosition = Input.mousePosition;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Nose"))
        {
            Debug.Log("You Win!");
            hasCollided = true;
            // Optionally, you can add more actions here such as stopping the movement of the finger
        }
    }
}

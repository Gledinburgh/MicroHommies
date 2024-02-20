using UnityEngine;

public class CardsController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 dragStartPosition;
    private Rigidbody2D rb;

    // Target Y position for winning
    private float targetY = 0.98f;

    // Speed of card movement
    public float moveSpeed = 5f;

    // Minimum and maximum y positions
    public float minY = -10f;
    public float maxY = 0.98f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            dragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = Mathf.Clamp(mousePosition.y, minY, maxY); // Clamp y position
            Vector2 dragDelta = mousePosition - dragStartPosition;

            // Ensure movement is only vertical
            dragDelta.x = 0f;

            rb.velocity = dragDelta * moveSpeed;

            // Check if the card has reached or exceeded the target Y position
            if (transform.position.y >= targetY)
            {
                // Set the position directly to the target Y position
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

                // Stop dragging
                isDragging = false;

                // Trigger win condition
                Debug.Log("You win!");
                // You can add additional logic here for game win state
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}

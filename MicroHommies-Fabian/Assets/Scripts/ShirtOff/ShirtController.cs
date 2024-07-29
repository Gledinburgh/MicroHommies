using UnityEngine;

public class ShirtController : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 dragStartPosition;
    private Rigidbody2D rb;

    // Target Y position for winning
    private float targetY = 1.35f;

    // Speed of card movement
    public float moveSpeed = 5f;

    // Minimum and maximum y positions
    public float minY = -10f;
    public float maxY = 1.35f;

   public MGM1 mgm;

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

            // Debug logs to check the values
            Debug.Log($"Current Y Position: {transform.position.y}");
            Debug.Log($"Target Y Position: {targetY}");

            // Check if the card has reached or exceeded the target Y position
            if (transform.position.y >= targetY)
            {
                // Set the position directly to the target Y position
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z);

                // Stop dragging
                isDragging = false;

                // Trigger win condition
                
                
                HandleWinCondition();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    void HandleWinCondition()
    {
        // You can implement the logic to handle the win condition here.
        // For example, you can load the next scene or display a win message.

        Debug.Log("You won!");
        mgm.LoadNextMicrogame();
        //GameManager.Instance.LoadNextMicrogame(); // Call the LoadNextMicrogame method from the GameManager script
    }
}


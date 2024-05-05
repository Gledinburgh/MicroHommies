using UnityEngine;

public class DraggableObject2 : MonoBehaviour
{
    private bool isDragging = false;
    private bool isShaking = false; // Flag to track if shaking animation is active
    private bool isClicked = false; // Flag to track if the object is clicked
    private Vector3 originalPosition; // Store the original position of the tooth
    private Vector3 clickPosition; // Store the position where the object is clicked
    private float dragThreshold = 0.5f; // Threshold for drag distance to start shaking (adjust as needed)
    private float shakeAmount = 5f; // Amount of shake rotation
    private float shakeSpeed = 10f; // Speed of shake animation
    private Rigidbody2D rb; // Rigidbody component for applying gravity

    private void Start()
    {
        originalPosition = transform.position; // Save the original position
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody component
        rb.gravityScale = 0f; // Initially, disable gravity
    }

    private void Update()
    {
        if (!isDragging && Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isClicked = true;
                clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (isClicked && !isDragging && Input.GetMouseButton(0))
        {
            float dragDistance = Mathf.Abs(clickPosition.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            if (dragDistance > dragThreshold)
            {
                isDragging = true;
                isShaking = true; // Start shaking animation
                StartCoroutine(ShakeTooth());
            }
        }

        if (isDragging && Input.GetMouseButtonUp(0))
        {
            isClicked = false;
            isDragging = false;
        }
    }

    // Coroutine for shake animation
    private System.Collections.IEnumerator ShakeTooth()
    {
        float elapsedTime = 0f;

        while (isShaking && elapsedTime < 2f) // Continue shaking for 2 seconds
        {
            // Shake animation by rotating the tooth slightly left and right
            transform.rotation = Quaternion.Euler(0f, 0f, shakeAmount);
            yield return new WaitForSeconds(1f / shakeSpeed);
            transform.rotation = Quaternion.Euler(0f, 0f, -shakeAmount);
            yield return new WaitForSeconds(1f / shakeSpeed);
            elapsedTime += 2f / shakeSpeed; // Update elapsed time
        }

        isShaking = false; // Stop shaking animation

        yield return new WaitForSeconds(0.5f); // Delay before enabling gravity

        rb.gravityScale = 1f; // Enable gravity
    }
}

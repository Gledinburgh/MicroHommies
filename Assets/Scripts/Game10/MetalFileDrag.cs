using UnityEngine;

public class MetalFileDrag : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Rigidbody2D rb;

    public CollisionHandler10 collisionHandler;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        rb.velocity = Vector2.zero; // Stop any previous movement
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + offset.x, transform.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bars"))
        {
            collisionHandler.SetDirection(transform.position.x < collision.transform.position.x);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bars"))
        {
            // Call IncrementMovementCount when MetalFile exits Bars
            collisionHandler.IncrementMovementCount();
        }
    }
}

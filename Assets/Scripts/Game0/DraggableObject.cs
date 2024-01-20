using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private bool isDragging = false;
    public bool isActive = true;
    private Vector3 offset;

    void Update()
    {
        if (isActive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null && hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }

            if (isDragging && Input.GetMouseButton(0))
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            }

            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }
        }
    }
}
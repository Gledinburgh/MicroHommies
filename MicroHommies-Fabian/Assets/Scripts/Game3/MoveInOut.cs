using UnityEngine;

public class MoveInOut : MonoBehaviour
{
    public Transform targetPoint; 
    public Transform startPoint;
    public Transform finalPoint;
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private Vector3 finalPosition;

    public Sprite[] handSprites;
    public SpriteRenderer spriteRenderer;

    public bool isActive;

    private bool movingIn = true;

    void Start()
    {              
       startPosition = startPoint.position;
        transform.position = startPosition;

        targetPosition = targetPoint.position;
        finalPosition = finalPoint.position;

        spriteRenderer.sprite = handSprites[0];

        
    }

    void Update()
    {
        if (isActive)
        {

        // Move the object towards the target position
            if (movingIn)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

                // Check if the object has reached the target position
                if (transform.position.y <= targetPosition.y)
                {
                    movingIn = false;
                    spriteRenderer.sprite = handSprites[1];
                }
            }
            else
            {
                // Move the object towards the final position
           
                // Check if the object has reached the final position
                if (transform.position.y <= finalPosition.y)
                {

                    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);


                }
            }
        }
    }
}

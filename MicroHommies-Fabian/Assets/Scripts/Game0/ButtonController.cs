


using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Sprite buttonPressedSprite;
    public Sprite buttonUnpressedSprite;

    private SpriteRenderer spriteRenderer;

    public MGM0 mgm;

    public int clickCount = 0; // Variable to keep track of click count

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component
        // Set the initial sprite to unpressed
        spriteRenderer.sprite = buttonUnpressedSprite;
    }

    void Update()
    {
        // Check for 'e' key press or left mouse button press
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && clickCount < 3)
        {
            clickCount++; // Increment click count
            spriteRenderer.sprite = buttonPressedSprite; // Change sprite to pressed
        }

        // Check for 'e' key release or left mouse button release
        if (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0))
        {
            spriteRenderer.sprite = buttonUnpressedSprite; // Change sprite back to unpressed
        }

        // Check if click count reaches 3, indicating the win condition
        if (clickCount == 3)
        {
            // Call a method to handle the win condition (e.g., transition to the next scene)
            HandleWinCondition();
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

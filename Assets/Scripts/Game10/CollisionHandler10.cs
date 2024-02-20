using UnityEngine;

public class CollisionHandler10 : MonoBehaviour
{
    private int enterCount = 0;
    private int exitCount = 0;

    public int movementThreshold = 3; // Number of movements required to win the game

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MetalFile"))
        {
            enterCount++;
            CheckWinCondition();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MetalFile"))
        {
            exitCount++;
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        if (enterCount >= movementThreshold && exitCount >= movementThreshold)
        {
            Debug.Log("You Win!");
            // Implement Win Condition or Game Over Logic Here
        }
    }

    public void SetDirection(bool movingRight)
    {
        // This method sets the direction of movement (not used in the new approach)
        // You can remove it if it's not needed anymore
    }

    public void IncrementMovementCount()
    {
        // This method increments the movement count (not used in the new approach)
        // You can remove it if it's not needed anymore
    }
}

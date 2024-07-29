using UnityEngine;

public class MGM2 : MonoBehaviour
{
    private GameManager gamemanager; // Reference to the GameManager instance

    private void Awake()
    {
        // Get the GameManager instance
        gamemanager = GameManager.Instance;
    }

    public void LoadNextMicrogame()
    {
        // Call the EndMicrogame method from the GameManager script
        gamemanager.EndMicrogame(101); // Adjust the score as needed
    }
}

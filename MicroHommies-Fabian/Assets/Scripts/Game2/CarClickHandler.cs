using UnityEngine;

public class CarClickHandler : MonoBehaviour
{
    public bool isNewCar; // Set this to true for the new car, false for the old cars
    public MGM2 microgameManager; // Reference to the MGM2 instance

    private void Start()
    {
        // Find the MGM2 instance in the scene
        //microgameManager = FindObjectOfType<MGM2>();
    }

    private void OnMouseDown()
    {
        if (isNewCar)
        {
            Debug.Log("Correct! You clicked the new car.");
            // Call a method to handle the correct selection
            HandleCorrectSelection();
        }
        else
        {
            Debug.Log("Wrong! You clicked an old car.");
            // Call a method to handle the wrong selection, if needed
            HandleWrongSelection();
        }
    }

    private void HandleCorrectSelection()
    {
        // Implement logic for when the correct car is clicked
        // For example, end the microgame with a positive score
        microgameManager.LoadNextMicrogame(); // Adjust the score as needed
    }

    private void HandleWrongSelection()
    {
        // Implement logic for when a wrong car is clicked
        // For example, end the microgame with a negative score or no change
        Debug.Log("Try again!");
    }
}

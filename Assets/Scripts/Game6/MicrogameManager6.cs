using UnityEngine;

public class MicrogameManager6 : MonoBehaviour
{
    private TimerManager timerManager;
    private GameManager gameManager;
    private CountDownManager countDownManager;
    private CardsController cardsController;

    public bool isWin;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
        countDownManager = FindObjectOfType<CountDownManager>();
        cardsController = FindObjectOfType<CardsController>();

        countDownManager.isActive = true;

        if (timerManager != null && !isWin)
        {
            timerManager.OnTimerExpired.AddListener(Lose);
        }
        else
        {
            Debug.LogError("TimerManager not found!");
        }
    }

    private void EndMicrogame()
    {
        gameManager.EndMicrogame(1);
        Debug.Log("Microgame ended. Score: " + CalculateScore());
    }

    private int CalculateScore()
    {
        // Add logic to calculate the microgame score based on player performance
        return 100;
    }

    // Method to call when the player wins
    public void Win()
    {
        if (isWin != true)
        {
            countDownManager.isActive = false;
            timerManager.SetTime(5f);
            isWin = true;
            Debug.Log("Game4 win");
            Invoke("EndMicrogame", 3f);
        }
    }

    // Method to call when the player loses
    private void Lose()
    {
        if (!isWin)
        {
            countDownManager.isActive = false;
            Invoke("EndMicrogame", 3f);
        }
    }

    // Method to check win condition based on DraggableObject position
    public void CheckWinCondition(Vector3 objectPosition)
    {
        // Add logic here to determine if the player has won
        // For example, if the DraggableObject is in the right position
        if (/* Add condition based on DraggableObject position */ true)
        {
            Win();
        }
    }
}

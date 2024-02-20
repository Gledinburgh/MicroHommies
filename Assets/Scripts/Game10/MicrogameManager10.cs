using UnityEngine;

public class MicrogameManager10 : MonoBehaviour
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

    private void Lose()
    {
        if (!isWin)
        {
            countDownManager.isActive = false;
            Invoke("EndMicrogame", 3f);
        }
    }
}

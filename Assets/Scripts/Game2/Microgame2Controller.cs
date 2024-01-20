using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microgame2Controller : MonoBehaviour
{
    private TimerManager timerManager;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();

        if (timerManager != null)
        {
            timerManager.OnTimerExpired.AddListener(EndMicrogame);
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
}

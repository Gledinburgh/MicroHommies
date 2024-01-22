using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameManager3 : MonoBehaviour
{
    private TimerManager timerManager;
    private GameManager gameManager;
    private CountDownManager countDownManager;
    private AngleControl angleControl;
   

    public bool isWin;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
        countDownManager = FindObjectOfType<CountDownManager>();
        angleControl = FindObjectOfType<AngleControl>();
        angleControl.isActive = true;
        countDownManager.isActive = true;

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

    public void Win()
    {
        if (isWin != true)
        {
          
            countDownManager.isActive = false;
            timerManager.SetTime(3f);
            angleControl.isActive = false;
            isWin = true;
            Debug.Log("Game3 win");
        }

        //End Game
    }

    private void Lose()
    {
        EndMicrogame();
    }


}
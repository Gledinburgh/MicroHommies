using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameManager5 : MonoBehaviour
{
    private TimerManager timerManager;
    private GameManager gameManager;
    private CountDownManager countDownManager;
    private ArmAngleControl angleControl;

    public bool isWin;

    private void Awake()
    {
        gameManager = GameManager.Instance;

    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
        countDownManager = FindObjectOfType<CountDownManager>();
        angleControl = FindObjectOfType<ArmAngleControl>();
       
        angleControl.isActive = true;
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
            isWin = true;

            //turn off micro game mechanics
            angleControl.isActive = false;
            countDownManager.isActive = false;
            timerManager.SetTime(5f);

            // Activate Win animations
            
            Debug.Log("Game5 win");
            Invoke("EndMicrogame", 3f);
        }

        //End Game
    }

    private void Lose()
    {
        if (!isWin)
        {
            countDownManager.isActive = false;           
            angleControl.isActive = false;          
            Invoke("EndMicrogame", 3f);
        }

    }


}
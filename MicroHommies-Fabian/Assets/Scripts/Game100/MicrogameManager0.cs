using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameManager0 : MonoBehaviour
{
    private TimerManager timerManager;
    private GameManager gameManager;
    //private CountDownManager countDownManager;
    public HueCycler hueCycler;
    private DraggableObject draggableObject;
    public BorderManager borderManager;

    public bool isWin;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
        //countDownManager = FindObjectOfType<CountDownManager>();
        //hueCycler = FindObjectOfType<HueCycler>();
        draggableObject = FindObjectOfType<DraggableObject>();

        //countDownManager.isActive = true;

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
        draggableObject.isActive = false;
        //countDownManager.isActive = false;
        //timerManager.SetTime(3f);
        hueCycler.isActive = true;
        isWin = true;
        borderManager.isWin = true;
        Invoke("EndMicrogame", 3);

        }
        
        //End Game
    }

    private void Lose()
    {
        EndMicrogame();
    }


}
